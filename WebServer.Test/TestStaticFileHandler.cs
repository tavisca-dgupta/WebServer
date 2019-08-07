using MyWebServer;
using System;
using System.Linq;
using Xunit;

namespace WebServer.Test
{
    public class TestStaticFileHandler
    {
        [Fact]

        public void Test_Virtual_Path_To_Local_Path()
        {
            //arrange
            StaticFileHandler file = new StaticFileHandler();
            //act
            string filePath = file.ResolveVirtualPath("google.com/hello.htm", "C://WebPages//google", "google.com");
            //assert
            Assert.Equal("C://WebPages//google/hello.htm", filePath);
        }
        [Fact]
        public void Test_Get_File_Content()
        {
            //arrange
            StaticFileHandler file = new StaticFileHandler();
            //act
            string fileContent = file.TryGetFile("C://WebPages//google//hello.htm");
            //assert
            Assert.Equal("<HTML><BODY><h1>Hello</h1></BODY></HTML>", fileContent);
        }

        [Fact]
        public void Test_Fecthing_File_Content_When_File_Does_Not_Exist()
        {
            //arrange
            StaticFileHandler file = new StaticFileHandler();
            //act
            string fileContent = file.TryGetFile("C://WebPages//google//index.htm");
            //assert
            Assert.Equal("<HTML><BODY><h1>404 Not Found</h1><p>Web Page not found!!!!!!!!!!!</p></BODY></HTML>", fileContent);
        }



    }
}
