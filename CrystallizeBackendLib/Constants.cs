using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    public class Constants
    {
        /// <summary>
        /// all the strings are readonly so that they can be intialized using constructor
        /// </summary>
        public static string JAVA_API_ADDRESSS;
        public static readonly string INSERT_SERVLET = "/Insert";
        public static readonly string DELETE_SERVLET = "/Delete";
        public static readonly string QUERY_SERVLET = "/Query";
        public static readonly string CREATE_TABLE_SERVLET = "/CreateTable";
    }
}
