using MyWebServer;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using Xunit;

namespace WebServer.Test
{
    public class TestListener
    {
        [Fact]
        public void Test_Server_isListening()
        {
            //arrange
            Http_Listener http_Listener = new Http_Listener();
            Socket webSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 8080);
            webSocket.Bind(localEndPoint);
            webSocket.Listen(10);
            //act
            Socket listenerSocket = http_Listener.StartListening();

            //assert
            Assert.Equal(webSocket, listenerSocket);
        }
    }
}
