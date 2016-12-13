using Microsoft.Data.Entity;
using WebApplication_Webease_.Models;

namespace WebApplication_Webease_.Services.DAL
{
    public class BPDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Projects> Portfolios { get; set; }
    }
}
