using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class RESTApi
    {

        public static void SendPostResponse(string requestBody,Socket senderSocket)
        {
            string[] body = requestBody.Split(',');
            string[] data=new string[2];
            for(int i=0;i<body.Length;i++)
            {
                if(body[i].Contains("year"))
                {
                    data = body[i].Split(':');
                    break;
                }
            }
            
            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(GetHttpHeader().ToString()));
            response.AddRange(Encoding.ASCII.GetBytes("Year is Leap :"+IsLeapYear(data[1])));
            byte[] responseByte = response.ToArray();
            senderSocket.Send(responseByte);
        }
        public static void SendGetResponse(string responseString, Socket senderSocket)
        {
            
            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(GetHttpHeader().ToString()));
            response.AddRange(Encoding.ASCII.GetBytes("This api calculate the year is a leap year or not when given a post request"));
            byte[] responseByte = response.ToArray();
            senderSocket.Send(responseByte);
        }

        private static bool IsLeapYear(string year)
        {
            string[] tempArray = year.Split('}');
            int leapYear = 0;
            int.TryParse(tempArray[0], out leapYear);
            if (leapYear % 100 == 0)
            {
              if (leapYear % 400 == 0)
                    return true;
            }
            else if(leapYear % 4 == 0 )
            {
                return true;
            }
            return false;
        }

        private static StringBuilder GetHttpHeader()
        {
            StringBuilder sbHeader = new StringBuilder();
            sbHeader.AppendLine("HTTP/1.1 200 OK");
            sbHeader.AppendLine("Content-Type: application/json" + ";charset=UTF-8");
            sbHeader.AppendLine();
            return sbHeader;
        }
    }
}
