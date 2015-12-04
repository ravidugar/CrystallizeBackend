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
            CrystallizeBackendLib.CrystallizeBackendLib.Initialize("http://testenvironment-gxecgpjx3p.elasticbeanstalk.com/");

            //TestInsert.SaveData();

            TestQuery.GetData();

            TestDelete.DeleteData();
           
            Console.ReadLine();
            
        }
    }
}
