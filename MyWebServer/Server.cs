using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Server
    {
        private Http_Listener http_Listener;

        public Server()
        {
            http_Listener = new Http_Listener();
        }
        public void Run()
        {
            http_Listener.StartListening();
            http_Listener.OnConnectionReceived();
        }
        
    }
}
