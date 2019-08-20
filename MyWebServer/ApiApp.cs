using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class ApiApp
    {
        
        public void AssignRoute(string request,string[] token,Socket senderSocket)
        {
                string[] requestBody;
                requestBody = request.Split('{');
                RestApi.SendResponse(request, token,senderSocket);
            
        }
    }
}
