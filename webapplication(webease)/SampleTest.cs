using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace webapplication_webease_
{
    // see example explanation on xUnit.net website:
    // https://xunit.github.io/docs/getting-started-dnx.html

    
    public class SampleTest
    {
        public string ChangeFileExtension(string firstfileext,string secondfileext, string fileName)
        {   var newDocExtension = "";
            if (fileName.EndsWith(firstfileext))
            {
                newDocExtension = fileName.Replace(firstfileext,secondfileext);
            }
            return newDocExtension;
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal("curriculumvitea.docx", ChangeFileExtension(".pdf",".docx","curriculumvitea.pdf"));
        }

        
    }
}
