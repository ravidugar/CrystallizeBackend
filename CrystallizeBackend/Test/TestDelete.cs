using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    class TestDelete
    {
        public static void DeleteData()
        {
            CrystallizeBackendLib.Request request = new CrystallizeBackendLib.Request();

            request.ID = "123";

            request.table = "Test";
            
            request.requestType = CrystallizeBackendLib.RequestType.DELETE;

            bool retVal = CrystallizeBackendLib.WebRequest<object>.DeleteData(request);

            if (retVal == false)
            {
                Console.WriteLine("Delete Test failed");
            }
        }
    }
}
