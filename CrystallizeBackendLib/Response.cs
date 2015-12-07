using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    public class Response<T>
    {
        // call back, reuest obect class change// get rid of webreuest
        /// <summary>
        /// store the success
        /// </summary>
        public bool ok { get; set; }

        /// <summary>
        /// store the return data
        /// </summary>
        public List<T> results { get; set; }

        /// <summary>
        /// store the message
        /// </summary>
        public string message { get; set; }
    }
}
