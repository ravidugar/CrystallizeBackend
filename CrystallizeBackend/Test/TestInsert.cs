using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    class TestInsert
    {
        public static void SaveData()
        {
            Person person = new Person() { Age = 25, Name = "Ravi Dugar" };

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
