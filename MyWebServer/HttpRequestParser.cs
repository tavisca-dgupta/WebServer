using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class HttpRequestParser
    {
        public static string[] RequestParser(string requestData)
        {
            var requestParameters = requestData.Split('\n');
            string[] tokens = requestParameters[0].Split(' ');
           
                return tokens;
            
        }

        public static string[] GetRequestParameters(string requestData)
        {
            return requestData.Split('\n'); 
        }
    }
}
