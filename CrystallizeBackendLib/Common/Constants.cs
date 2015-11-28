using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    public class Constants
    {
        static Constants()
        {
            JAVA_API_ADDRESSS = "http://gabedemo-h7jfpifzv2.elasticbeanstalk.com"; // code to read from some xml config
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
