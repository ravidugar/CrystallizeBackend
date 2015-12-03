using System;
using System.Collections.Generic;
using System.Text;

namespace CrystallizeBackendLib
{
    public class CrystallizeBackendLib
    {
        public static bool Initialize(string serverAddress)
        {
            if (serverAddress == null || String.IsNullOrEmpty(serverAddress)) return false;
            serverAddress = serverAddress.TrimEnd('/');
            Constants.JAVA_API_ADDRESSS = serverAddress;
            return true;
        }
    }
}
