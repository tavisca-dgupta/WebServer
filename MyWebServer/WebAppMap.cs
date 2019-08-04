using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class WebAppMap
    {
        private static Dictionary<string,string> _webApps = new Dictionary<string,string>();
        public static string GetRootDirectory(string webBaseUrl)
        {
            return _webApps[webBaseUrl];
        }
        public static bool IsWebAppPresent(string webBaseUrl)
        {
            return _webApps.ContainsKey(webBaseUrl);
        }
    }
}
