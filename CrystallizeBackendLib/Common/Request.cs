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
        public string CollectionName { get; set; }

        /// <summary>
        /// Specifies all the conditions for the query
        /// eg : get all players with names equal to Ravi or Peter and age is 50
        /// Condition.Add("name", new List<object>());
        /// Collection["name"].Add("Ravi");
        /// Collection["name"].Add("Peter");
        /// Condition.Add("age", new List<object>())
        /// Coniditon["age"].Add(50);
        /// </summary>
        public Dictionary<string, List<object>> Conditions
        {
            get { return this.conditions; }
            set { this.conditions = value; }
        }

        /// <summary>
        /// private members
        /// </summary>
        private Dictionary<string, List<object>> conditions = new Dictionary<string, List<object>>();
    }

    public class Request
    {
        /// <summary>
        /// Data to be written during Insert operation
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Specified which database to be queried from
        /// </summary>
        public DatabaseType DatabaseType { get; set; }
        
        /// <summary>
        /// Specifies what response is desired
        /// </summary>
        public ResponseType ResponseType { get; set; }
        
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
        /// Not in use
        /// </summary>
        public List<String> Outputs
        {
            get { return this.outputs; }
            set { this.outputs = value; }
        }

        /// <summary>
        /// private members
        /// </summary>
        private List<Query> queries = new List<Query>();
        private List<string> filters = new List<string>();
        private List<string> outputs = new List<string>();
    }
}
