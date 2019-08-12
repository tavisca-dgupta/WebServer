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
            if (token[0].Equals("POST"))
            {
                requestBody = request.Split('{');
                ApiHandle.SendPostResponse(requestBody[1],senderSocket);
            }
            else
            {
                ApiHandle.SendGetResponse("Year",senderSocket);
            }

        }
    }
}
