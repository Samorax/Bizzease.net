﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using WebApplication_Webease_.Models;

namespace WebApplication_Webease_.Services.DAL
{
    public class IdentityContext:IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    
}
