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


    class TestInsert
    {


        public static void SaveData()
        {
            Person person = new Person() { Age = 25, Name = new FullName() { Firstname = "Ravi", Lastname = "Dugar" } };

            string test = CrystallizeBackendLib.JSONConverter<Person>.SerializeObject(person);

            Console.WriteLine(test);

            Person x = CrystallizeBackendLib.JSONConverter<Person>.DeserializeObject(test);



            CrystallizeBackendLib.Request request = new CrystallizeBackendLib.Request();

            request.ID = "234";
            
            request.table = "Test";
            
            request.requestType = CrystallizeBackendLib.RequestType.INSERT;

            bool retVal = CrystallizeBackendLib.WebRequest<object>.SaveData(request, person);

            if (retVal == false)
            {
                Console.WriteLine("Insert Test failed");
            }
        }
    }
}
