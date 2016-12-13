using Microsoft.Data.Entity;
using WebApplication_Webease_.Models;

namespace WebApplication_Webease_.Services.DAL
{
    public class DashBoardDbContext:DbContext
    {
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
