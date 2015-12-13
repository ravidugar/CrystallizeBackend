using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// Holds the query to be made to the JAVA API
    /// </summary>
    public class Query
    {
        /// <summary>
        /// Initializes the values list
        /// </summary>
        public Query()
        {
            this.values = new List<object>();
        }

        /// <summary>
        /// Table / Collection name to be queried from 
        /// </summary>
        public string attribute { get; set; }

        /// <summary>
        /// operation to be performed
        /// </summary>
        public string op { get; set; }

        /// <summary>
        /// Specifies all the values to be compared against
        /// </summary>
        public List<object> values { get; set; }
    }

    /// <summary>
    /// Class to hold the contents of a request to be sent to the JAVA API 
    /// </summary>
    /// <typeparam name="T">Type for which the request is being made</typeparam>
    public class Request<T>
    {
        /// <summary>
        /// Constructor to initialize the table name
        /// Every request requires a tablename
        /// </summary>
        /// <param name="tablename">table or collection for which the request is to be made</param>
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
        /// <param name="filterName">Attribute names</param>
        public void AddFilter(params string[] filterNames)
        {
            this.filters.AddRange(filterNames);
        }

        /// <summary>
        /// Method makes a HTTP request to the JAVA API
        /// </summary>
        /// <returns>Response object containing the desired response from the JAVA API</returns>
        private Response<T> GetResponse()
        {
            try
            {
                string requestURIString = GetRequestURIString();

                var webRequest = (HttpWebRequest)System.Net.WebRequest.Create(requestURIString);

                webRequest.Method = "POST";

                webRequest.ContentType = "application/json";

                var data = JSONConverter<Request<T>>.SerializeObject(this);

                byte[] dataBytes = System.Text.Encoding.ASCII.GetBytes(data);

                var webRequestStream = webRequest.GetRequestStream();

                webRequestStream.Write(dataBytes, 0, dataBytes.Length);

                webRequestStream.Close();

                // code to get response
                var webResponse = (HttpWebResponse)webRequest.GetResponse();

                var response = new Response<T>();

                if (webResponse.StatusCode != HttpStatusCode.OK) return response; // failure

                var webResponseStream = webResponse.GetResponseStream();

                var readStream = new StreamReader(webResponseStream);

                var result = readStream.ReadToEnd();

#if DEBUG
                Console.WriteLine(result);
#endif
                response = JSONConverter<Response<T>>.DeserializeObject(result);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get the response : " + ex.Message);
                return new Response<T>() { ok = false, message = "Failed to get the response : " + ex.Message };
            }
        }

        #region Methods without Callbacks

        /// <summary>
        /// Method to Get data from the database
        /// </summary>
        /// <returns>Response object with results containing the collection desired as per the Query</returns>
        public Response<T> GetData()
        {
            this.requestType = RequestType.QUERY;
            
            var response = GetResponse();

            return response;
        }

        /// <summary>
        /// Method save the data to the database
        /// </summary>
        /// <param name="obj">Object whose data has to be saved</param>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> SaveData(T obj)
        {
            this.requestType = RequestType.INSERT;

            this.document = obj;

            Response<T> response = GetResponse();

            return response;
        }

        /// <summary>
        /// Method to delete a row from a particular collection
        /// </summary>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> DeleteData()
        {
            this.requestType = RequestType.DELETE;

            var response = GetResponse();

            return response;
        }

        /// <summary>
        /// Method to add a table to the database
        /// </summary>
        /// <param name="keyName">Name of the attribute considered as key</param>
        /// <param name="keyType">Data type of the key</param>
        /// <param name="writeThroughput">Write capacity for the table with default as 5 units</param>
        /// <param name="readThroughput">Read capacity for the table with default as 5 units</param>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> CreateTable(string keyName = "ID", TableKeyType keyType = TableKeyType.String, int writeThroughput = 5, int readThroughput = 5)
        {
            this.requestType = RequestType.ADD_TABLE;

            this.key = new Key() { name = keyName, type = keyType.ToString() };

            this.throughput = new Throughput() { write = writeThroughput, read = readThroughput };

            var response = GetResponse();

            return response;
        }

        /// <summary>
        /// Method to delete a table from a database
        /// </summary>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> DeleteTable()
        {
            this.requestType = RequestType.DELETE_TABLE;

            var response = GetResponse();

            return response;
        }

        #endregion

        #region Methods with Callbacks

        /// <summary>
        /// Method to Get data from the database
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>Response object with results containing the collection desired as per the Query</returns>
        public Response<T> GetData(Action<object> callback)
        {
            this.requestType = RequestType.QUERY;

            var response = GetResponse();

            if (callback != null)
            {
                callback(response);
            }

            return response;
        }

        /// <summary>
        /// Method save the data to the database 
        /// </summary>
        /// <param name="obj">Object whose data has to be saved</param>
        /// <param name="callback"></param>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> SaveData(T obj, Action<object> callback)
        {
            this.requestType = RequestType.INSERT;

            this.document = obj;

            var response = GetResponse();

            if (callback != null)
            {
                callback(response);
            }

            return response;
        }

        /// <summary>
        ///  Method to delete a row from a particular collection
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> DeleteData(Action<object> callback)
        {
            this.requestType = RequestType.DELETE;

            var response = GetResponse();

            if (callback != null)
            {
                callback(response);
            }

            return response;
        }

        /// <summary>
        /// Method to add a table to the database
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="keyName">Name of the attribute considered as key</param>
        /// <param name="keyType">Data type of the key</param>
        /// <param name="writeThroughput">Write capacity for the table with default as 5 units</param>
        /// <param name="readThroughput">Read capacity for the table with default as 5 units</param>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> CreateTable(Action<object> callback, string keyName = "ID", TableKeyType keyType = TableKeyType.String, int writeThroughput = 5, int readThroughput = 5)
        {
            this.requestType = RequestType.ADD_TABLE;

            this.key = new Key() { name = keyName, type = keyType.ToString() };

            this.throughput = new Throughput() { write = writeThroughput, read = readThroughput };

            var response = GetResponse();

            if (callback != null)
            {
                callback(response);
            }

            return response;
        }

        /// <summary>
        /// Method to delete a table from a database
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>Response object with ok as true in case of success and false along with a failure message otherwise</returns>
        public Response<T> DeleteTable(Action<object> callback)
        {
            this.requestType = RequestType.DELETE_TABLE;

            var response = GetResponse();

            if (callback != null)
            {
                callback(response);
            }

            return response;
        }

        #endregion

        /// <summary>
        /// Forms the proper / complete URL for the request to be made
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

                case RequestType.ADD_TABLE: return retVal + Constants.ADD_TABLE_SERVLET;

                case RequestType.DELETE_TABLE: return retVal + Constants.DELETE_TABLE_SERVLET;
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
        /// Sets the read / write properties of a table
        /// </summary>
        public Throughput throughput { get; set; }

        /// <summary>
        /// The details of the key for a table
        /// </summary>
        public Key key { get; set; }

        #endregion
    }

    /// <summary>
    /// Sets the various properties of a table
    /// </summary>
    public class Throughput
    {
        /// <summary>
        /// Write capacity (default = 5)
        /// </summary>
        public int write { get; set; }
        
        /// <summary>
        /// Read capacity (default = 5)
        /// </summary>
        public int read { get; set; }
    }

    /// <summary>
    /// Class to hold the details of the key for a table
    /// </summary>
    public class Key
    {
        /// <summary>
        /// name of the attribute to be considered as a key
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// data type of the key (refer TableKeyType.cs)
        /// </summary>
        public string type { get; set; }

    }
}
