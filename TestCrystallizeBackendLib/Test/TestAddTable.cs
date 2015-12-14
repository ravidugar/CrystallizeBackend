using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCrystallizeBackendLib
{
    /// <summary>
    /// Class to test create table method
    /// </summary>
    class TestAddTable
    {
        /// <summary>
        /// 
        /// </summary>
        public static void AddTable()
        {
            AddTest1();

            AddTest2();
        }

        /// <summary>
        /// Table creation with default settings
        /// </summary>
        private static void AddTest1()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test");

            var response = request.AddTable();

            if (response.ok == false)
            {
                Console.WriteLine("Add table test 1 failed : " + response.message);
            }
        }

        /// <summary>
        /// Table creation with user settings
        /// </summary>
        private static void AddTest2()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test2");

            var response = request.AddTable(keyName:"ID", keyType:CrystallizeBackendLib.TableKeyType.Integer, writeThroughput:3, readThroughput:3); 

            if (response.ok == false)
            {
                Console.WriteLine("Add table test 2 failed : " + response.message);
            }
        }
    }
}
