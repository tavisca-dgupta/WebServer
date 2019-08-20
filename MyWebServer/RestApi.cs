using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class RestApi
    {
       
        public static void SendResponse(string request, string[] token, Socket senderSocket)
        {
            string name = token[1].Replace("Api/", "");
            RouteOperations routeOperations = new RouteOperations();
            string data = request.Split('{')[1];
            MethodDetail _methodDetails = new MethodDetail();
            string methodName = _methodDetails.GetMethod("POST", name);
            var output = routeOperations.GetType().GetMethod(methodName).Invoke(routeOperations, new object[] { data });
            List<byte> response = new List<byte>();
            response.AddRange(Encoding.ASCII.GetBytes(GetHttpHeader().ToString()));
            response.AddRange(Encoding.ASCII.GetBytes(output.ToString()));
            byte[] responseByte = response.ToArray();
            senderSocket.Send(responseByte);
        }

        private static StringBuilder GetHttpHeader()
        {
            StringBuilder sbHeader = new StringBuilder();
            sbHeader.AppendLine("HTTP/1.1 200 OK");
            sbHeader.AppendLine("Content-Type: application/json" + ";charset=UTF-8");
            sbHeader.AppendLine();
            return sbHeader;
        }
    }
}
