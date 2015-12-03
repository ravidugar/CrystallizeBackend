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
            CrystallizeBackendLib.Request request = new CrystallizeBackendLib.Request();

            request.requestType = CrystallizeBackendLib.RequestType.QUERY;

            request.ID = "234";

            request.table = "Test";

            request.AddQuery("ID", CrystallizeBackendLib.Operator.EQ, new List<object>(){"234"});

            List<Person> result = CrystallizeBackendLib.WebRequest<List<Person>>.GetData(request);
            
            Console.WriteLine(result[0].Name);
        }
    }
}
