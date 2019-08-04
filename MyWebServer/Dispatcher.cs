using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Dispatcher
    {
        private WebApp _webApp;
        public bool AssignWebApp(Socket senderSocket)
        {
            NetworkStream communicationChannel = new NetworkStream(senderSocket);
            byte[] byteData = new byte[1024];
            int byteDataCount = communicationChannel.Read(byteData, 0, byteData.Length);
            string request = Encoding.ASCII.GetString(byteData, 0, byteDataCount);
            string[] requestTokens = HttpRequestParser.PraseRequest(request);
            if (WebAppMap.IsWebAppPresent(requestTokens[1]))
            {
                _webApp = new WebApp(requestTokens[1], WebAppMap.GetRootDirectory(requestTokens[1]));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
