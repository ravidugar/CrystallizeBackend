using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    public class TestCreateTable
    {
        public static void CreateTable()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test2");

            request.CreateTable();
        }
    }
}
