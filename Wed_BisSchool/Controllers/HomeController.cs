using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ApplicationDbContext.Create()));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ApplicationDbContext.Create()));
            var role = new IdentityRole();
            role.Name = "Test";
            roleManager.Create(role);
            return View();
        }
    }
}