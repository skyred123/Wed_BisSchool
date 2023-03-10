using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_BisSchool.Models;

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
            var list = dbContext.Sources.ToList();
            if (list.Count() == 0)
            {
                return View();
            }
            return View(list);
        }
        // GET: Courses/Create
        public ActionResult Create()
        {
            var list = dbContext.Categories.ToList();
            ViewBag.CategoriesList = new SelectList(list,"Id","Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cource cource)
        {
            return RedirectToAction("Index","Home");
        }
    }
}