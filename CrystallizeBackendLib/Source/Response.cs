using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// Generic class to hold the response received from the JAVA API for any request made
    /// </summary>
    /// <typeparam name="T">The type for which the request was made</typeparam>
    public class Response<T>
    {
        /// <summary>
        /// store the success (true if successful request was made, false otherwise)
        /// </summary>
        public bool ok { get; set; }

        /// <summary>
        /// store the return data collection
        /// </summary>
        public List<T> results { get; set; }

        /// <summary>
        /// store the message in case of failure
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// return the first result if not null
        /// </summary>
        public T result
        {
            get 
            {
                if (results != null && results.Count > 0)
                {
                    return results[0];
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
