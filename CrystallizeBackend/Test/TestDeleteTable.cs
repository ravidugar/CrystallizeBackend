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
            var request = new CrystallizeBackendLib.Request<object>("Test");

            var response = request.DeleteTable();

            if (response.ok == false)
            {
                Console.WriteLine("Delete table failed : " + response.message);
            }
        }
    }
}
