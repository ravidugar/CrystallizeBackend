using System;
using System.Collections.Generic;
using System.Text;

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

    public class Request
    {
        public Request()
        {
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
