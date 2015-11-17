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
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8080/CrystallizeBackend/Query");

            //HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            //Stream receiveStream = webResponse.GetResponseStream();

            //StreamReader readStream = new StreamReader(receiveStream);

            //Console.WriteLine(webResponse.ContentType);

            //Console.WriteLine(readStream.ReadToEnd());

            Person p = new Person() { Age = 25, Name = "Ravi" };

            Console.WriteLine (CrystallizeBackendLib.Utils.JSONConverter<Person>.SerializeObject(p));

            Console.ReadLine();
        }
    }
}
