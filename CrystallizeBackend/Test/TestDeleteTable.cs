using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    /// <summary>
    /// Class to test delete table feature
    /// </summary>
    class TestDeleteTable
    {
        /// <summary>
        /// 
        /// </summary>
        public static void DeleteTable()
        {
            DeleteTest1();

            DeleteTest2();
        }

        /// <summary>
        /// Delete test table
        /// </summary>
        private static void DeleteTest1()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test");

            var response = request.DeleteTable();

            if (response.ok == false)
            {
                Console.WriteLine("Delete table test 1 failed : " + response.message);
            }
        }

        /// <summary>
        /// Deleting Test2 table
        /// </summary>
        private static void DeleteTest2()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test2");

            var response = request.DeleteTable();

            if (response.ok == false)
            {
                Console.WriteLine("Delete table test 2 failed : " + response.message);
            }
        }
    }
}
