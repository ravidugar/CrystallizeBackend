using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    class TestQuery
    {
        public static void GetData()
        {
            CrystallizeBackendLib.Request request = new CrystallizeBackendLib.Request("Test");

            request.requestType = CrystallizeBackendLib.RequestType.QUERY;

            request.ID = "234";

            request.AddQuery("ID", CrystallizeBackendLib.Operator.EQ, "234", "25");

            List<Person> result = CrystallizeBackendLib.WebRequest<Person>.GetData(request);
            
            Console.WriteLine(result[0].Name);
        }
    }
}
