using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CrystallizeBackendLib.Utils
{
    public class JSONConverter<T>
    {
        /// <summary>
        /// Converts a JSON string to an object
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeObject(string data)
        {
            T retval = JsonConvert.DeserializeObject<T>(data);
            return retval;
        }

        /// <summary>
        /// Converts an Object to JSON string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(T obj)
        {
            string retval = JsonConvert.SerializeObject(obj);
            Console.WriteLine(retval);
            return retval;
        }
    }
}
