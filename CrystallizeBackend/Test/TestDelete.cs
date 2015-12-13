using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    /// <summary>
    /// Class to test delete a row from a table feature
    /// </summary>
    class TestDelete
    {
        /// <summary>
        /// 
        /// </summary>
        public static void DeleteData()
        {
            DeleteTest1();

            DeleteTest2();
        }

        /// <summary>
        /// Deleting an existing entry
        /// </summary>
        private static void DeleteTest1()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test");

            request.ID = "234";

            var response = request.DeleteData();

            if (response.ok == false)
            {
                Console.WriteLine("Delete Test 1 failed : " + response.message);
            }
        }

        /// <summary>
        /// Deleting a non-existing entry, the method should still return success
        /// </summary>
        private static void DeleteTest2()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test");

            request.ID = "300";

            var response = request.DeleteData();

            if (response.ok == false)
            {
                Console.WriteLine("Delete Test 2 failed : " + response.message);
            }
        }
    }
}
