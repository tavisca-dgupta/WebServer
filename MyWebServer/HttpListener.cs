using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MyWebServer
{
    public class Http_Listener
    {
        private Socket _webServerSocket;
        private IPEndPoint _localEndPoint;
        private Dispatcher _requestDispatcher;

        public Http_Listener()
        {
            _requestDispatcher = new Dispatcher();
        }
        public Socket StartListening(IPAddress iPAddress)
        {
            _webServerSocket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _localEndPoint = new IPEndPoint(iPAddress, 8888);
            _webServerSocket.Bind(_localEndPoint);
            _webServerSocket.Listen(10);
            Console.WriteLine("Server started!!!!!!!!!");
            return _webServerSocket;
        }

        public void OnConnectionReceived()
        {
            try
            {
                while(_webServerSocket.IsBound)
                {
                    Socket senderSocket = _webServerSocket.Accept();
                    Console.WriteLine("connected");
                    new Thread(_ =>
                    {
                        _requestDispatcher.AssignWebApp(_webServerSocket);
                        senderSocket.Shutdown(SocketShutdown.Both);
                        senderSocket.Close();
                    }).Start();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("unable to connect to server");
            }
        }
    }
}
