using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
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
            var person = new Person() {Age = 25, Name = new FullName() { Firstname = "Ravi", Lastname = "Dugar" } };

            var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.ID = "234";
                        
            var response = request.SaveData(person);

            if (response.ok == false)
            {
                Console.WriteLine("Insert Test failed : " + response.message);
            }
        }
    }
}
