using Microsoft.AspNet.Mvc;
using System.Linq;
using WebApplication_Webease_.Services.DAL;

namespace WebApplication_Webease_.Controllers
{
    public class DashBoardController:Controller
    {
        private DashBoardDbContext DasbDbContext; 
        public DashBoardController(DashBoardDbContext _DasbDbContext)
        {
            DasbDbContext = _DasbDbContext;
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int customerId)
        {
            var customer = DasbDbContext.Customers.FirstOrDefault(c => c.CustomersId == customerId);
            return View(customer);
        }

    }
}
