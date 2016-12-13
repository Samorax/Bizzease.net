using System.Collections.Generic;

namespace WebApplication_Webease_.Models.ViewModels
{
    public class ViewBlogModel
    {


        public ViewBlogModel(string a, string b, System.DateTime c, string d, IEnumerable<Comment> e)
        {
            BlogName = a;
            BlogTag = b;
            BlogDate = c;
            BlogBody = d;
            BlogComments = e;
        }

        public string BlogName { get; set; }
        public string BlogTag { get; set; }
        public System.DateTime BlogDate { get; set; }
        public string BlogBody { get; set; }

        public IEnumerable<Comment> BlogComments { get; set; }
    }
}
