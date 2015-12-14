using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCrystallizeBackendLib
{
    /// <summary>
    /// Class to test save data to table feature
    /// </summary>
    class TestInsert
    {
        /// <summary>
        /// 
        /// </summary>
        public static void SaveData()
        {
            SaveTest1();

            SaveTest2();
        }

        /// <summary>
        /// Save simple object
        /// </summary>
        private static void SaveTest1()
        {
            var person = new Person() { Age = 25, Name = new FullName() { Firstname = "Ravi", Lastname = "Dugar" } };

            var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.ID = "234";

            var response = request.SaveData(person);

            if (response.ok == false)
            {
                Console.WriteLine("Save Test 1 failed : " + response.message);
            }
        }

        /// <summary>
        /// Insert complex object with list
        /// </summary>
        private static void SaveTest2()
        {
            var person = new Person1() { Age = 30, Name = new FullName() { Firstname = "Ravi", Lastname = "Dugar" }, CollegeName = new List<string>() };

            person.CollegeName.Add("Cornell University");

            var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.ID = "236";

            var response = request.SaveData(person);

            if (response.ok == false)
            {
                Console.WriteLine("Save Test 2 failed : " + response.message);
            }
        }
    }
}
