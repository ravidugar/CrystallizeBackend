using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib.Common
{
    public class Query
    {
        /// <summary>
        /// Collection name to be queried from 
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// operation to be performed
        /// </summary>
        public Operator Operator { get; set; }

        /// <summary>
        /// Specifies all the values to be compared
        /// </summary>
        public List<object> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        /// <summary>
        /// private members
        /// </summary>
        private List<object> values = new List<object>();
    }

    public class Request
    {
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
        public string document { get; set; }

        /// <summary>
        /// Specifies the request type (Insert, Delete or Query/Find)
        /// </summary>
        public RequestType requestType { get; set; }
        
        /// <summary>
        /// Specifies the conditions (where clause)
        /// </summary>
        public List<Query> queries
        {
            get { return this.queries1; }
            set { this.queries1 = value; }
        }
        
        
        /// <summary>
        /// Desired output attributes
        /// </summary>
        public List<string> filters
        {
            get { return this.filters1; }
            set {   this.filters1 = value;}
        }

        /// <summary>
        /// private members
        /// </summary>
        private List<Query> queries1 = new List<Query>();
        private List<string> filters1 = new List<string>();
    }
}
