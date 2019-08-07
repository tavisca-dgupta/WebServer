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
        public WebAppMap()
        {
            _webApps.Add("google.com", "C://WebPages//google/");
            _webApps.Add("stackoverflow.com", "C://WebPages//stackoverflow/");
        }
        public string GetRootDirectory(string webBaseUrl)
        {
            return _webApps[webBaseUrl];
        }
        public bool IsWebAppPresent(string webBaseUrl)
        {
            return _webApps.ContainsKey(webBaseUrl);
        }
    }
}
