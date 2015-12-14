using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCrystallizeBackendLib
{
    /// <summary>
    /// Class to test Query feature
    /// </summary>
    class TestQuery
    {
        /// <summary>
        /// 
        /// </summary>
        public static void GetData()
        {
            GetTest1();

            GetTest2();

            GetTest3();
        }

        /// <summary>
        /// Query for single entry
        /// </summary>
        private static void GetTest1()
        {
            var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.AddQuery("Age", CrystallizeBackendLib.Operator.EQ, 25);

            var response = request.GetData();

            if (response.ok == true && response.results.Count > 0)
            {
                Console.WriteLine("Result : " + response.result.Name.Firstname + " " + response.result.Name.Lastname + " " + response.result.Age);
            }
            else
            {
                Console.WriteLine("Query test 1 failed : " + response.message);
            }
        }

        /// <summary>
        /// Query for multiple entries
        /// </summary>
        private static void GetTest2()
        {
            var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.AddQuery("Age", CrystallizeBackendLib.Operator.GE, 25);

            var response = request.GetData();

            if (response.ok == true)
            {
                if (response.results.Count == 2)
                {
                    Console.WriteLine("Found all records");
                }
                else
                {
                    Console.WriteLine("Query test 2 failed : " + response.message);
                }
            }
            else
            {
                Console.WriteLine("Query test 2 failed : " + response.message);
            }
        }

        /// <summary>
        /// Query with filters
        /// </summary>
        private static void GetTest3()
        {
            var request = new CrystallizeBackendLib.Request<Person1>("Test");

            request.AddQuery("Age", CrystallizeBackendLib.Operator.EQ, 30);

            request.AddFilter("Name.FirstName", "Age");

            var response = request.GetData();

            if (response.ok == true && response.results.Count > 0 && String.IsNullOrEmpty(response.result.Name.Lastname))
            {
                Console.WriteLine("Result : " + response.result.Name.Firstname + " " + response.result.Age);
            }
            else
            {
                Console.WriteLine("Query test 3 failed : " + response.message);
            }
        }
    }
}
