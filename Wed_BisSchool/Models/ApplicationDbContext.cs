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
            dbContext.Sources.Include(e=>e.Lecturer).Include(e=>e.Category).Load();
            return dbContext;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Attendance>().HasRequired(a => a.Cource).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<Following>().HasKey(e=> new {e.FollowerId,e.FolloweeId});
            modelBuilder.Entity<ApplicationUser>().HasMany(u=>u.Followers).WithRequired(f=>f.Followee).WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Followees).WithRequired(f => f.Follower).WillCascadeOnDelete(false);
        }
        public DbSet<Cource> Sources { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Following> Followings { get; set; }
    }
}