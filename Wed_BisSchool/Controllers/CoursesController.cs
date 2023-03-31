using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                var list = dbContext.Sources.ToList();
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
                viewModel.Heading = "Add Course";
                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var course = dbContext.Sources.Single(e => e.Id == id && e.LecturerId == userid);
            var model = new CourceViewModel()
            {
                Categories = dbContext.Categories.ToList(),
                Date = course.DateTime.ToString("yyyy-MM-dd"),
                Time = course.DateTime.ToString("hh:mm"),
                CategoryId = course.CategoryId,
                Place= course.Place,
                Heading = "Edit Course",
                Id= course.Id,
            };
            return View("Create",model);
        }
        [HttpPost]
        public ActionResult Update(CourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Categories= dbContext.Categories.ToList();
                return View("Create",model);
            }
            var userid = User.Identity.GetUserId() ;
            var cource = dbContext.Sources.Single(e => e.Id == model.Id && e.LecturerId == userid);
            cource.Place = model.Place;
            cource.DateTime = model.GetDateTime();
            cource.CategoryId = model.CategoryId;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var userid = User.Identity.GetUserId();
            var course =dbContext.Sources.Single(e => e.Id == id && e.LecturerId == userid);
            dbContext.Sources.Remove(course);
            dbContext.SaveChanges();
            return RedirectToAction("Mine", "Courses");
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
            return RedirectToAction("Mine","Courses");
        }
        public ActionResult Attending()
        {
            var userid = User.Identity.GetUserId();
            var sourses = dbContext.Attendances.Where(a=>a.AttendeeId == userid)
                                               .Select(a=>a.Cource)
                                               .ToList();
            var viewModel = new CourcesViewModel()
            {
                upcomingCource= sourses,
                ShowAction = User.Identity.IsAuthenticated,
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Following()
        {
            var userid = User.Identity.GetUserId();
            var following = dbContext.Followings.Where(a => a.FollowerId == userid)
                                               .Select(a => a.Followee)
                                               .ToList();
            var course = new List<Cource>();
            foreach(var follow in following) {
                course.Add(dbContext.Sources.Where(e=>e.LecturerId == follow.Id).FirstOrDefault());
            }
            var viewModel = new CourcesViewModel()
            {
                upcomingCource = course,
                ShowAction = User.Identity.IsAuthenticated,
            };
            return View(viewModel);
        }
        [Authorize]
        public ActionResult Mine() { 
            var userid = User.Identity.GetUserId();
            var course = dbContext.Sources.Where(e => e.LecturerId == userid && e.DateTime > DateTime.Now);
            return View(course);
        }
    }
}