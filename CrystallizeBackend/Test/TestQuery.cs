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

            request.AddQuery("age", CrystallizeBackendLib.Operator.EQ, new List<object>(){25});

            Person result = CrystallizeBackendLib.WebRequest<Person>.GetData(request);
            
            Console.WriteLine(result.Name);
        }
    }
}
