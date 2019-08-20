namespace MyWebServer
{
    public interface IFileSystem
    {
       string ResolveVirtualPath(string virtualPath, string rootDirectoryPath,string websiteUrl);
        string TryGetFile(string filePath);
    }
}