using System.Linq;
using WebApplication_Webease_.Models;
using WebApplication_Webease_.Services.DAL;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using WebApplication_Webease_.Services;

namespace WebApplication_Webease_.Controllers
{

    public class BlogEditorController : Controller
    {
        private readonly BPDbContext _context;
        private readonly IDocConverter _converter;

        public BlogEditorController(BPDbContext context,IDocConverter converter)
        {
            _context = context;
            _converter = converter;
           
        }

        // GET: BlogEditor
        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }

        // GET: BlogEditor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var blog = _context.Blogs.Single(m => m.BlogId == id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }

        // GET: BlogEditor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogEditor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include:"BlogTag,BlogDate,BlogAuthor,BlogSummary,BlogTitle,BlogBody")]Blog blog,IFormFile BlogBody)
        {
            await _converter.ConvertWordToRazorViewAsync(BlogBody, blog);
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(blog);


        }

        // GET: BlogEditor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var blog = _context.Blogs.Single(m => m.BlogId == id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: BlogEditor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Update(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: BlogEditor/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var blog = _context.Blogs.Single(m => m.BlogId == id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }

        // POST: BlogEditor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var blog = _context.Blogs.Single(m => m.BlogId == id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
