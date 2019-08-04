namespace MyWebServer
{
    public interface IFileSystem:IHttpHandle
    {
        string ResolveVirtualPath(string virtualPath, string rootDirectoryPath,string websiteUrl);
        string TryGetFile(string filePath);
    }
}