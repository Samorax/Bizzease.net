using System;
using System.Linq;
using WebApplication_Webease_.Services;
using WebApplication_Webease_.Models.ViewModels;
using WebApplication_Webease_.Models;
using WebApplication_Webease_.Services.DAL;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using System.IO;

namespace WebApplication_Webease_.Controllers
{
    [Route("/")]
        public class HomeController : Controller
        {
            private IOptions<WebMail> _webmailsettings;
            private IMailSender _mailSender;
            private static List<Comment> allComments;
            private  BPDbContext _context;
            private static int listCounter { get; set; }
            private static List<Blog> allBlogs { get; set; }
            
            //Summary:
            //        Return the maximun number of blog per page (five blogs).
            private static List<Blog> LatestBlogs(List<Blog> blogs)
            {
                var FiveBlogs = new List<Blog>();
                for (int i = 0; i < blogs.Count(); i++)
                {
                    if (i == 5)
                    {
                        break;
                    }
                    FiveBlogs.Add(allBlogs[i]);
                }
                return FiveBlogs;
            }
            
            //Summary:
            //        Return the number of pages of blogs.
            private static void returnListCounter(List<Blog> allBlogs)
            {
                var divisionOutput = 0;
                var divisionRemainder = 0;
                if (allBlogs.Count() > 5)
                {
                    divisionOutput = allBlogs.Count() / 5;
                }
                if (allBlogs.Count() % 5 != 0)
                {
                    divisionRemainder = 1;
                }

                listCounter = divisionOutput + divisionRemainder;
            }
            
            //Sunnary:
            //        Return the list of pages of blogs.
            private static List<int> returnListOfPages(int listCounter)
            {
                var i = 1;
                var listOfPages = new List<int>();
                while(i < listCounter)
                {
                    i++;
                    listOfPages.Add(i);
                }
                return listOfPages;   
            }
            
            //Summary:
            //       Return all the blogs and comments from the database.
            private static void QueryDb(BPDbContext _context)
            {
                allBlogs = _context.Blogs.ToList();
                allComments = _context.Comments.ToList();
            }

            public HomeController(IOptions<WebMail> webmailSettings, IMailSender mailSender, BPDbContext BPcontext)
            {
                _webmailsettings = webmailSettings;
                _mailSender = mailSender;
                _context = BPcontext;
                QueryDb(_context);
            }   
            
            [Route("/")]
            public IActionResult Index()
            {
                ViewData["latestblogs"] = LatestBlogs(allBlogs);
                return View();
            }
            
            //Summary:
            //      Return the About page.
            [Route("/about")]
            public IActionResult about()
            {
                return View();
            }
            
            //Summary:
            //      Return the contact page
            [Route("/contact")]
            public IActionResult contact()
            {
                return View();
            }
            
            //Summary:
            //      Process httpPost data of contact page
            [Route("/contact")]
            [HttpPost]
            public IActionResult contact([Bind(include: "FirstName,LastName,Email,Message")] ContactForm form)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var email = _webmailsettings.Value.Email;
                        _mailSender.SendMessage(email, "WebMail", $"{form.FirstName} {form.LastName}:{form.Email},{form.Tel}<br>{form.Message}");
                        ViewBag.MessageSuccess = "Message Sent";
                    }
                    catch (Exception e)
                    {
                        ViewBag.MessageFailed = $"An Error Occurred, while trying to send message: {e.InnerException.Message}. Please try again or Contact the Web Admin @ {"damexix7@gmail.com"}";
                    }
                   
                }
                return View(form);
            }

            //Summary:
            //        return the latest five blogs.
            [Route("/blogs")]
            public IActionResult blogs()
            {
                var FiveBlogs = LatestBlogs(allBlogs);
                returnListCounter(allBlogs);
                ViewData["listOfPages"] = returnListOfPages(listCounter);
                return View(FiveBlogs.OrderByDescending(b => b.BlogDate));    
            }

            //Summary:
            //        return the business_consultancy page
            [Route("/services/business_consultancy")]
            public IActionResult business_consultancy()
            {
                return View();
            }

            //Summary:
            //        return the web_mobile_application page
            [Route("/services/web_mobile_application")]
            public IActionResult web_mobile_application()
            {
                return View();
            }

            //Summary:
            //       return the accounting page
            [Route("/services/accounting")]
            public IActionResult accounting()
            {
                return View();
            }

            //Summary:
            //       return the caseStudies page
            [Route("/caseStudies")]
            public IActionResult caseStudies()
            {
                return View();
            }
            
            [Route("/CaseStudies_Downloads")]
            public FileResult CaseStudies_Downloads()
            {
                var filename = "Charity-CaseStudies-Webease.pdf";
                var filepath = $"CaseStudies/{filename}";
                var filebyte = System.IO.File.ReadAllBytes(filepath);
                return File(filebyte, "application/pdf", filename);
            }

            //Summary:
            //      return a blog with the specified id.
            [Route("/blogs/viewblog/{id}")]
            public IActionResult viewblog(int id)
            { 
                var blog = _context.Blogs.FirstOrDefault(b=>b.BlogId.Equals(id));

                if (_context.Comments.Any())
                {
                    //Get all sequence, where comments instance have this blog id
                    var blogComments = _context.Comments.Where(c => c.BlogId.Equals(id)).ToList();
                    ViewData["blogComments"] = blogComments;
                }
                return View(blog);

            }
            
            //Ajax call action
            [HttpPost("/blogs/viewblog/comment")]
            public IActionResult Comments(Comment readerComment,int BlogId)
            {
                //Assign the associated blog to the comment.
                readerComment.BlogId = BlogId;

                //Verify user inputs
                if (ModelState.IsValid)
                {
                    try
                    {
                        //if user input is genuine: add comment to db.
                        allComments.Add(readerComment);
                        _context.SaveChanges();
                        ModelState.Clear();
                        //return feedback message to user.
                        ViewData["CommentPostedSuccess"] = "Comment posted successfully";
                    }
                    catch (Exception e)
                    {
                    //return feedback message to user.
                    ViewData["CommentPostedError"] = $"An error occurred:{e.InnerException.Message}. Try again later";
                    
                    }
 
                }
                return PartialView("_commentFeedback",readerComment);
            }
            
            //Summary:
            //      Process the httpPost data of the home contact form.
            [HttpPost("/HomeContactForm")]
            public IActionResult HomeContactForm([Bind(include:"Name,Email,ProjectDescription")] HomeContactForm form)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var ReceiverEmail = _webmailsettings.Value.Email;
                        _mailSender.SendMessage(ReceiverEmail, "Project in a nutshell", $"Message from {form.Name}; {form.Email}: {form.ProjectDescription}");
                        ViewData["MessageSuccess"] = "Your message has been delivered. We will get back to you shortly";
                        ModelState.Clear();
                        return PartialView("_homeContactForm");
                    }
                    catch (Exception e)
                    {
                        ViewData["MessageErorr"] = $"An Error Occurred while trying to send your message: {e.InnerException.Message}. Please try again later";
                        return PartialView("_homeContactForm");
                    }
        
                }
                return PartialView("_homeContactForm",form);
            }

           //Summary:
           //       Return the what we do page.
           [Route("/whatwedo")]
           public IActionResult Whatwedo()
            {
                return View("mission");
            }
            

            [Route("/Error")]
            public IActionResult Error()
            {
                return View();
            }
    }
}
