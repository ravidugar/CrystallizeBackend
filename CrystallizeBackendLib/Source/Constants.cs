using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// Holds all the relative servlet addresses
    /// Each of the servlet corresponds to the different functionalities supported by the JAVA API at the other end
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// all the strings are readonly so that they can be intialized using static constructor
        /// </summary>
        static Constants()
        {
            INSERT_SERVLET = "/Insert";
            DELETE_SERVLET = "/Delete";
            QUERY_SERVLET = "/Query";
            ADD_TABLE_SERVLET = "/AddTable";
            DELETE_TABLE_SERVLET = "/DeleteTable";
        }

        public static string JAVA_API_ADDRESSS;
        public static readonly string INSERT_SERVLET;
        public static readonly string DELETE_SERVLET;
        public static readonly string QUERY_SERVLET;
        public static readonly string ADD_TABLE_SERVLET;
        public static readonly string DELETE_TABLE_SERVLET;
    }
}
