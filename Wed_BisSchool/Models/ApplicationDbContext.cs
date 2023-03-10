using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Wed_BisSchool.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            ApplicationDbContext dbContext= new ApplicationDbContext();
            dbContext.Sources.Include(e=>e.Category).Load();
            return dbContext;
        }
        public DbSet<Cource> Sources { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}