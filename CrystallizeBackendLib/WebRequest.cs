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
        private static Response GetResponse(Request request)
        {
            string requestURIString = GetRequestURIString(request.requestType);

            HttpWebRequest webRequest = (HttpWebRequest)System.Net.WebRequest.Create(requestURIString);

            webRequest.Method = "POST";

            webRequest.ContentType = "application/json";

            // write code to convert the request object to xml
            string data = JSONConverter<Request>.SerializeObject(request);

            byte[] dataBytes = System.Text.Encoding.ASCII.GetBytes(data);

            Stream webRequestStream = webRequest.GetRequestStream();

            webRequestStream.Write(dataBytes, 0, dataBytes.Length);

            webRequestStream.Close();

            // code to get response
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            Response response = new Response();

            if (webResponse.StatusCode != HttpStatusCode.OK) return response; // failure

            Stream webResponseStream = webResponse.GetResponseStream();

            StreamReader readStream = new StreamReader(webResponseStream);

            string result = readStream.ReadToEnd();

#if DEBUG
            Console.WriteLine(result);
#endif
            response = JSONConverter<Response>.DeserializeObject(result);

            return response;
        }

        public static T GetData(Request request)
        {
            request.requestType = RequestType.QUERY;

            // code to get response
            Response response = GetResponse(request);

            if (response.ok == false)
            {
                T retVal = JSONConverter<T>.DeserializeObject(response.result);

                return retVal;
            }

            return default(T);
        }

        public static bool SaveData(Request request, T obj)
        {
            request.requestType = RequestType.INSERT;

            request.document = obj;

            Response response = GetResponse(request);

            return response.ok;
        }

        public static bool DeleteData(Request request)
        {
            request.requestType = RequestType.DELETE;

            Response response = GetResponse(request);

            return response.ok;
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
