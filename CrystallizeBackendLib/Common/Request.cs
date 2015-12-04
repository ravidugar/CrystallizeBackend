using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace CrystallizeBackendLib
{
    public class Query
    {
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

    public class Request<T>
    {
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

        public Response<T> GetData()
        {
            this.requestType = RequestType.QUERY;

            // code to get response
            Response<T> response = GetResponse();

            return response;
        }

        public Response<T> SaveData(T obj)
        {
            this.requestType = RequestType.INSERT;

            this.document = obj;

            Response<T> response = GetResponse();

            return response;
        }

        public Response<T> DeleteData()
        {
            this.requestType = RequestType.DELETE;

            Response<T> response = GetResponse();

            return response;
        }
        
        private String GetRequestURIString()
        {
            string retVal = Constants.JAVA_API_ADDRESSS;

            switch (requestType)
            {
                case RequestType.DELETE: return retVal + Constants.DELETE_SERVLET;

                case RequestType.INSERT: return retVal + Constants.INSERT_SERVLET;

                case RequestType.QUERY: return retVal + Constants.QUERY_SERVLET;
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

        #endregion
    }
}
