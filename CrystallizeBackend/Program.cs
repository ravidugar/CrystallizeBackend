using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;


namespace CrystallizeBackend
{
    
    public class Person
    {
        public FullName Name { get; set; }
        public int Age { get; set; }
    }

    public class College
    {
        public string CollegeName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TestInsert.SaveData();

            TestQuery.GetData();

            //TestDelete.DeleteData();
           
            Console.ReadLine();
            
        }
    }
}
