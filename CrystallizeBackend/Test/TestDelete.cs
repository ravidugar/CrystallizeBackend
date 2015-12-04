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
            var request = new CrystallizeBackendLib.Request<object>("Test");

            request.ID = "234";
            
            var response = request.DeleteData();
           
            if (response.ok == false)
            {
                Console.WriteLine("Delete Test failed");
            }
        }
    }
}
