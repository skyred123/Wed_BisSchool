using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_BisSchool.Models;
using Wed_BisSchool.ViewModel;

namespace Wed_BisSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CoursesController()
        {
            dbContext = ApplicationDbContext.Create();
        }
        // GET: Courses
        public ActionResult Index()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var list = dbContext.Sources.ToList().Where(e=>e.LecturerId == User.Identity.GetUserId());
                if (list.Count() == 0)
                {
                    return View();
                }
                return View(list);
            }
            return RedirectToAction("Index", "Home");
        }
        // GET: Courses/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var viewModel = new CourceViewModel();
                viewModel.Categories = dbContext.Categories.ToList();
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Create(CourceViewModel courceViewModel)
        {
            var item = new Cource();
            item.LecturerId = User.Identity.GetUserId();
            item.DateTime = courceViewModel.GetDateTime();
            item.Place = courceViewModel.Place;
            item.CategoryId = courceViewModel.CategoryId;
            dbContext.Sources.Add(item);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}