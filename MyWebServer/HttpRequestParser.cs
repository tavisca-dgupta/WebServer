using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class HttpRequestParser
    {
        public static string[] PraseRequest(string requestData)
        {
            var requestParameters = requestData.Split('\n');
            string[] tokens = requestParameters[0].Split(' ');
            if(tokens[0].ToLower().Equals("get"))
            {
                return tokens;
            }
            else
            {
                Console.WriteLine("only get method supported");
                return null;
            }

        }
    }
}
