using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Dispatcher
    {
        private WebApp _webApp;
        private WebAppMap _webAppMap;
        public Dispatcher()
        {
            _webAppMap = new WebAppMap();
        }
        public bool AssignWebApp(Socket senderSocket)
        {
            NetworkStream communicationChannel = new NetworkStream(senderSocket);
            byte[] byteData = new byte[1024];
            int byteDataCount = communicationChannel.Read(byteData, 0, byteData.Length);
            string request = Encoding.ASCII.GetString(byteData, 0, byteDataCount);
            string[] requestTokens = HttpRequestParser.PraseRequest(request);
            string[] suburls = requestTokens[1].Split('/');
            if (_webAppMap.IsWebAppPresent(suburls[1]))
            {
                _webApp = new WebApp("/"+suburls[1], _webAppMap.GetRootDirectory(suburls[1]),senderSocket);
                _webApp.HandleRequest(requestTokens[1]);
                return true;
            }
            else
            {
                StringBuilder sbHeader = new StringBuilder();
                sbHeader.AppendLine("HTTP/1.1 200 OK");
                sbHeader.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
                sbHeader.AppendLine();
                List<byte> response = new List<byte>();
                response.AddRange(Encoding.ASCII.GetBytes(sbHeader.ToString()));
                string file = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>";
                response.AddRange(Encoding.ASCII.GetBytes(file));
                byte[] responseByte = response.ToArray();
                senderSocket.Send(responseByte);
                return false;
            }
        }
    }
}
