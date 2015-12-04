using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    public class FullName
    {
        public string Firstname {get;set;}
        public string Lastname{get;set;}
    }

    public class Person1 : Person
    {
        public string CollegeName { get; set; }
    }

    class TestInsert
    {
        public static void SaveData()
        {
            var person = new Person() {Age = 25, Name = new FullName() { Firstname = "Ravi", Lastname = "Dugar" } };

            var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.ID = "236";
                        
            var retVal = request.SaveData(person);

            if (retVal.ok == false)
            {
                Console.WriteLine("Insert Test failed");
            }
        }
    }
}
