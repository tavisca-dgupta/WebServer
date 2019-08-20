using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Error
    {
        public static void PageNotFoundError(Socket senderSocket)
        {
            StringBuilder sbHeader = new StringBuilder();
            sbHeader.AppendLine("HTTP/1.0 404 Not Found");
            sbHeader.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
            sbHeader.AppendLine();
            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(sbHeader.ToString()));
            string file = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>";
            response.AddRange(Encoding.ASCII.GetBytes(file));
            byte[] responseByte = response.ToArray();
            senderSocket.Send(responseByte);
        }
    }
}
