using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class WebApp
    {
        public StringBuilder responseHeader;
        private StaticFileHandler _staticFileHandler;
        private string _baseUri;
        private string _rootDirectory;
        private Socket _senderSocket;
        private string _filePath;
        public WebApp(string baseUri,string rootDirectory,Socket senderSocket)
        {
            _baseUri = baseUri;
            _staticFileHandler = new StaticFileHandler();
            _senderSocket = senderSocket;
            _rootDirectory = rootDirectory;
        }
        public void HandleRequest(string url)
        {
            _filePath = _staticFileHandler.ResolveVirtualPath(url,_rootDirectory,_baseUri);
            SendResponse();
        }
        public void SendResponse()
        {
            string file = _staticFileHandler.TryGetFile(_filePath);
            if(string.IsNullOrEmpty(file))
            {
                Error.PageNotFoundError(_senderSocket);
            }
            else
            {
                responseHeader = new StringBuilder();
                responseHeader.AppendLine("HTTP/1.1 200 OK");
                responseHeader.AppendLine("Content-Type: text/html" + ";charset=UTF-8");
                responseHeader.AppendLine();
                List<byte> response = new List<byte>();
                response.AddRange(Encoding.ASCII.GetBytes(responseHeader.ToString()));
                response.AddRange(Encoding.ASCII.GetBytes(file));
                byte[] responseByte = response.ToArray();
                _senderSocket.Send(responseByte);
            }
        }
    }
}
