using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib.Common
{
    public class Response
    {
        /// <summary>
        /// store the success
        /// </summary>
        public bool Ok { get; set; }
 
        /// <summary>
        /// store the return message
        /// </summary>
        public string Result { get; set; }
    }
}
