using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_BisSchool.Models;
using System.Data.Entity;
using Wed_BisSchool.ViewModel;

namespace Wed_BisSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public HomeController()
        {
            dbContext = ApplicationDbContext.Create();
        }
        public ActionResult Index()
        {

            var upcomingCources = dbContext.Sources.ToList();

            var viewModel = new CourcesViewModel()
            {
                upcomingCource = upcomingCources,
                ShowAction = User.Identity.IsAuthenticated,
            };
            return View(viewModel);
        }
    }
}