using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    /// <summary>
    /// Class to test Query feature
    /// </summary>
    class TestQuery
    {
        /// <summary>
        /// 
        /// </summary>
        public static void GetData()
        {
           var request = new CrystallizeBackendLib.Request<Person>("Test");

            request.AddQuery("Age", CrystallizeBackendLib.Operator.EQ, 234, 25);

            var response = request.GetData();

            if (response.ok == true)
            {
                Console.WriteLine(response.results[0].Name);
            }
            else if (String.IsNullOrEmpty(response.message))
            {
                Console.WriteLine("Data not found");
            }
            else
            {
                Console.WriteLine("Query failed : " + response.message);
            }
        }
    }
}
