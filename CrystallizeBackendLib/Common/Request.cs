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
        public string Table { get; set; }

        /// <summary>
        /// Specifies the object Id
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// Data to be written during Insert operation
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Specifies the request type (Insert, Delete or Query/Find)
        /// </summary>
        public RequestType RequestType { get; set; }
        
        /// <summary>
        /// Specifies the conditions (where clause)
        /// </summary>
        public List<Query> Queries
        {
            get { return this.queries; }
            set { this.queries = value; }
        }
        
        
        /// <summary>
        /// Desired output attributes
        /// </summary>
        public List<string> Filters
        {
            get { return this.filters; }
            set {   this.filters = value;}
        }

        /// <summary>
        /// private members
        /// </summary>
        private List<Query> queries = new List<Query>();
        private List<string> filters = new List<string>();
    }
}
