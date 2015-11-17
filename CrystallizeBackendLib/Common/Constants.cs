using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib.Common
{
    public class Constants
    {
        static Constants()
        {
            JAVA_API_ADDRESSS = "http://localhost:8080/CrystallizeBackend"; // code to read from some xml config
        }

        /// <summary>
        /// all the strings are readonly so that they can be intialized using constructor
        /// </summary>
        public static readonly string JAVA_API_ADDRESSS;
        public static readonly string INSERT_SERVLET = "/Insert";
        public static readonly string DELETE_SERVLET = "/Delete";
        public static readonly string QUERY_SERVLET = "/Query";
    }
}
