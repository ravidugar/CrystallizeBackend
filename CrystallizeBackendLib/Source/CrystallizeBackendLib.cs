using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    /// <summary>
    /// It initializes the library
    /// </summary>
    public class CrystallizeBackendLib
    {
        /// <summary>
        /// Initializes the JAVA_API address with the URL of the server
        /// </summary>
        /// <param name="serverAddress"></param>
        /// <returns>true if intialization is successful</returns>
        public static bool Initialize(string serverAddress)
        {
            try
            {
                if (serverAddress == null || String.IsNullOrEmpty(serverAddress)) return false;
                // trim the last / as the servlet addresses handles it (refer Constants.cs)
                serverAddress = serverAddress.TrimEnd('/');
                Constants.JAVA_API_ADDRESSS = serverAddress;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Initialization failed : " + ex.Message);
                return false;
            }
        }
    }
}
