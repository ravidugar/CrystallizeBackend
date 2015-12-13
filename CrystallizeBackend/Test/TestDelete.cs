﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystallizeBackend
{
    /// <summary>
    /// Class to test delete a row from a table feature
    /// </summary>
    class TestDelete
    {
        /// <summary>
        /// 
        /// </summary>
        public static void DeleteData()
        {
            var request = new CrystallizeBackendLib.Request<object>("Test");

            request.ID = "234";
            
            var response = request.DeleteData();
           
            if (response.ok == false)
            {
                Console.WriteLine("Delete Test failed : " + response.message);
            }
        }
    }
}
