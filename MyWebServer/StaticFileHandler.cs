using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class StaticFileHandler : IFileSystem
    {
        public string ResolveVirtualPath(string virtualPath, string rootDirectoryPath,string websiteUrl)
        {
            return virtualPath.Replace(websiteUrl, rootDirectoryPath);
        }

        public string TryGetFile(string filePath)
        {
            string data;
            try
            {
                data = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                data = "<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>";
            }
            return data;
        }
    }
}
