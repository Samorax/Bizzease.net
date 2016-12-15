using System.IO;
using Xunit;

namespace Webapplication_webease_.UnitTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {

        [Fact]
        public void UniTest1()
        {
            var currentdir = Directory.GetCurrentDirectory();
            var parentdir = new DirectoryInfo(currentdir).Parent.Name;
            var viewDir = new DirectoryInfo($"{parentdir}\\Views").Name;
            var expected = "WebApplication(Webease)\\Views";
            Assert.Equal(expected, viewDir, ignoreCase:true);
        }

        [Fact]
        public void Create_BlogUploads()
        {
            var currentdir = Directory.GetCurrentDirectory();
            var parentdir = new DirectoryInfo(currentdir).Parent.Name;
            var viewDir = new DirectoryInfo($"{parentdir}\\Views");
            var blogUploads = viewDir.CreateSubdirectory("BlogUploads");
            Assert.True(blogUploads.Name.Equals("BlogUploads"),$"The folder {blogUploads.Name} exists.");
        }

        [Fact]
        public void Move_File_to_BlogUploads()
        {
            var currentdir = Directory.GetCurrentDirectory();
            var parentdir = new DirectoryInfo(currentdir).Parent.Name;
            var viewDir = new DirectoryInfo($"{parentdir}\\Views");
            var blogUploads = viewDir.CreateSubdirectory("BlogUploads");
        }
    }
}
