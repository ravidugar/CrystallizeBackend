using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;


namespace TestCrystallizeBackendLib
{
    /// <summary>
    /// Start point for the test program application
    /// </summary>
    class Program
    {
        /// <summary>
        /// The method creates a Test table and performs all the operations on the table (insert, query and delete) and then deletes the table
        /// The tests are performed on dummy classes defined below in the same namespace
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CrystallizeBackendLib.CrystallizeBackendLib.Initialize("http://demo-ujyzsgm9iz.elasticbeanstalk.com/");

            TestAddTable.AddTable();

            TestInsert.SaveData();

            TestQuery.GetData();

            TestDelete.DeleteData();

            TestDeleteTable.DeleteTable();
           
            Console.ReadLine();
            
        }
    }


    /// <summary>
    ///
    /// </summary>
    class FullName
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class Person1 : Person
    {
        public List<string> CollegeName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class Person
    {
        public FullName Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class College
    {
        public string CollegeName { get; set; }
    }
}
