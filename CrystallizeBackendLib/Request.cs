using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 
        /// </summary>
        public Query()
        {
            this.values = new List<object>();
        }

        /// <summary>
        /// Collection name to be queried from 
        /// </summary>
        public string attribute { get; set; }

        /// <summary>
        /// operation to be performed
        /// </summary>
        public string op { get; set; }

        /// <summary>
        /// Specifies all the values to be compared
        /// </summary>
        public List<object> values { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Request<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename"></param>
        public Request(string tablename)
        {
            this.table = tablename;
            this.query = new List<Query>();
            this.filters = new List<string>();
        }

        #region Methods

        /// <summary>
        /// Adds a Query to Request
        /// </summary>
        /// <param name="attribute">Attribute name</param>
        /// <param name="op">Type of operation</param>
        /// <param name="values">Values to be compared against</param>
        public void AddQuery(string attribute, Operator op, params object[] values)
        {
            Query tempquery = new Query() { attribute = attribute, op = op.ToString() };
            tempquery.values.AddRange(values);
            this.query.Add(tempquery);
            
        }

        /// <summary>
        /// Adds a filter to request
        /// </summary>
        /// <param name="filterName">Attribute name</param>
        public void AddFilter(params string[] filterNames)
        {
            this.filters.AddRange(filterNames);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Response<T> GetResponse()
        {
            string requestURIString = GetRequestURIString();

            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(requestURIString);

            webRequest.Method = "POST";

            webRequest.ContentType = "application/json";

            // write code to convert the request object to xml
            string data = JSONConverter<Request<T>>.SerializeObject(this);

            byte[] dataBytes = System.Text.Encoding.ASCII.GetBytes(data);

            Stream webRequestStream = webRequest.GetRequestStream();

            webRequestStream.Write(dataBytes, 0, dataBytes.Length);

            webRequestStream.Close();

            // code to get response
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            Response<T> response = new Response<T>();

            if (webResponse.StatusCode != HttpStatusCode.OK) return response; // failure

            Stream webResponseStream = webResponse.GetResponseStream();

            StreamReader readStream = new StreamReader(webResponseStream);

            string result = readStream.ReadToEnd();

#if DEBUG
            Console.WriteLine(result);
#endif
            response = JSONConverter<Response<T>>.DeserializeObject(result);

            return response;
        }

        #region Methods without Callbacks

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Response<T> GetData()
        {
            this.requestType = RequestType.QUERY;

            // code to get response
            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Response<T> SaveData(T obj)
        {
            this.requestType = RequestType.INSERT;

            this.document = obj;

            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Response<T> DeleteData()
        {
            this.requestType = RequestType.DELETE;

            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="keyName"></param>
        /// <param name="keyType"></param>
        /// <param name="writeThroughput"></param>
        /// <param name="readThroughput"></param>
        /// <returns></returns>
        public Response<T> CreateTable(string tablename, string keyName = "ID", TableKeyType keyType = TableKeyType.String, int writeThroughput = 5, int readThroughput = 5)
        {
            this.requestType = RequestType.CREATE_TABLE;

            this.table = tablename;

            this.key = new Key() { name = keyName, type = keyType.ToString() };

            this.throughput = new Throughput() { write = writeThroughput, read = readThroughput };

            Response<T> response = GetResponse();

            return response;
        }

        #endregion

        #region Methods with Callbacks

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public Response<T> GetData(Action<object> callback)
        {
            this.requestType = RequestType.QUERY;

            // code to get response
            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public Response<T> SaveData(T obj, Action<object> callback)
        {
            this.requestType = RequestType.INSERT;

            this.document = obj;

            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public Response<T> DeleteData(Action<object> callback)
        {
            this.requestType = RequestType.DELETE;

            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="callback"></param>
        /// <param name="keyName"></param>
        /// <param name="keyType"></param>
        /// <param name="writeThroughput"></param>
        /// <param name="readThroughput"></param>
        /// <returns></returns>
        public Response<T> CreateTable(string tablename, Action<object> callback, string keyName = "ID", TableKeyType keyType = TableKeyType.String, int writeThroughput = 5, int readThroughput = 5)
        {
            this.requestType = RequestType.CREATE_TABLE;

            this.table = tablename;

            this.key = new Key() { name = keyName, type = keyType.ToString() };

            this.throughput = new Throughput() { write = writeThroughput, read = readThroughput };

            Response<T> response = GetResponse();

            return response;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private String GetRequestURIString()
        {
            string retVal = Constants.JAVA_API_ADDRESSS;

            switch (requestType)
            {
                case RequestType.DELETE: return retVal + Constants.DELETE_SERVLET;

                case RequestType.INSERT: return retVal + Constants.INSERT_SERVLET;

                case RequestType.QUERY: return retVal + Constants.QUERY_SERVLET;

                case RequestType.CREATE_TABLE: return retVal + Constants.CREATE_TABLE_SERVLET;
            }

            return retVal;
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Specifies the table name
        /// </summary>
        public string table { get; set; }

        /// <summary>
        /// Specifies the object Id
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Data to be written during Insert operation
        /// </summary>
        public object document { get; set; }

        /// <summary>
        /// Specifies the request type (Insert, Delete or Query/Find)
        /// </summary>
        public RequestType requestType { get; set; }
        
        /// <summary>
        /// Specifies the conditions (where clause)
        /// </summary>
        public List<Query> query { get; set; }        
        
        /// <summary>
        /// Desired output attributes
        /// </summary>
        public List<string> filters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Throughput throughput { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Key key { get; set; }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class Throughput
    {
        /// <summary>
        /// 
        /// </summary>
        public int write { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int read { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Key
    {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }

    }
}
