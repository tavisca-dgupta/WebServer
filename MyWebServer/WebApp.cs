using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class WebApp
    {
        private StaticFileHandler _staticFileHandler;
        private string _baseUri;
        private string _rootDirectory;
        public WebApp(string baseUri,string rootDirectory)
        {
            _baseUri = baseUri;
            _staticFileHandler = new StaticFileHandler();
            _rootDirectory = rootDirectory;
        }
        public void HandleRequest(HttpListenerRequest request)
        {
            _staticFileHandler.ResolveVirtualPath(request.Url.ToString(),_rootDirectory,_baseUri);            
        }
    }
}
