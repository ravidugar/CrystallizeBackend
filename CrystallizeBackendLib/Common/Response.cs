using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    public class Response
    {
        /// <summary>
        /// store the success
        /// </summary>
        public bool ok { get; set; }
 
        /// <summary>
        /// store the return message
        /// </summary>
        public string results { get; set; }
    }
}
