using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using CrystallizeBackendLib.Common;
using CrystallizeBackendLib.Utils;
using System.IO;

namespace CrystallizeBackendLib
{
    public class WebRequest<T>
    {
        private static HttpWebResponse MakeRequest(Request request)
        {
            string requestURIString = GetRequestURIString(request.RequestType);

            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(requestURIString);

            webRequest.Method = "POST";

            webRequest.ContentType = "text/xml; encoding='utf-8'"; // check this once

            // TODO : convert the request object into xml format
            string data = JSONConverter<Request>.SerializeObject(request); // write code to convert the request object to xml

            byte[] dataBytes = System.Text.Encoding.ASCII.GetBytes(data);

            Stream webRequestStream = webRequest.GetRequestStream();

            webRequestStream.Write(dataBytes, 0, dataBytes.Length);

            webRequestStream.Close();

            // code to get response
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            return webResponse;
        }

        public static T GetData(Request request)
        {
            request.RequestType = RequestType.QUERY;

            // code to get response
            HttpWebResponse webResponse = MakeRequest(request);

            if (webResponse.StatusCode != HttpStatusCode.OK) return default(T); // failure

            Stream webResponseStream = webResponse.GetResponseStream();

            StreamReader readStream = new StreamReader(webResponseStream);

            Response response = new Response();

            response.Data = readStream.ReadToEnd();

#if DEBUG
            Console.WriteLine(response.Data);
#endif

            T retVal = JSONConverter<T>.DeserializeObject(response.Data);

            return retVal;
        }

        public static bool SaveData(Request request)
        {
            bool retVal = true;

            request.RequestType = RequestType.INSERT;

            return retVal;
        }

        public static bool DeleteData(Request request)
        {
            bool retVal = true;

            request.RequestType = RequestType.DELETE;

            return retVal;
        }

        private static String GetRequestURIString(RequestType requestType)
        {
            string retVal = Constants.JAVA_API_ADDRESSS;

            switch (requestType)
            {
                case RequestType.DELETE: return retVal + Constants.DELETE_SERVLET;
                case RequestType.INSERT: return retVal + Constants.INSERT_SERVLET;
                case RequestType.QUERY: return retVal + Constants.QUERY_SERVLET;
            }

            return retVal;
        }
    }
}
