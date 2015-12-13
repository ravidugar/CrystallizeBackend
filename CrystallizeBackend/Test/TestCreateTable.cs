using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    /// <summary>
    /// Class to test create table method
    /// </summary>
    class TestCreateTable
    {
        /// <summary>
        /// 
        /// </summary>
        public static void CreateTable()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test");

            var response = request.CreateTable();

            if (response.ok == false)
            {
                Console.WriteLine("Create table failed : " + response.message);
            }
        }
    }
}
