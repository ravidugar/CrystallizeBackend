using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// This is a generic class to convert and object to JSON string and vice versa.
    /// It uses Newtonsoft.Json API to achieve this
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JSONConverter<T>
    {
        /// <summary>
        /// Converts a JSON string to an object
        /// </summary>
        /// <param name="data">Json string to be converted</param>
        /// <returns>An object of type T</returns>
        public static T DeserializeObject(string data)
        {
            try
            {
                T retval = JsonConvert.DeserializeObject<T>(data);
                return retval;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to convert Json string to the object : " + ex.Message);
                return default(T);
            }
        }

        /// <summary>
        /// Converts an Object to JSON string
        /// </summary>
        /// <param name="obj">An object of type T for which Json string is required</param>
        /// <returns>Json string if successful empty string otherwise</returns>
        public static string SerializeObject(T obj)
        {
            try
            {
                string retval = JsonConvert.SerializeObject(obj);
                Console.WriteLine(retval);
                return retval;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to serialize the object : " + ex.Message);
                return String.Empty;
            }
        }
    }
}
