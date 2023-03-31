using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.Controllers
{
    [Authorize]
    public class CaterorysController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public CaterorysController()
        {
            dbContext =  ApplicationDbContext.Create();
        }
        // GET: Caterorys
        public ActionResult Index()
        {
            var list = dbContext.Categories.ToList();
            if (list.Count() == 0)
            {
                return View();
            }
            return View(list);
        }

        // GET: Caterorys/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Caterorys/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {

                if (dbContext.Categories.FirstOrDefault(p => p.Name == category.Name) != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                category.Id = Convert.ToByte(dbContext.Categories.ToList().Count()+1);
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Caterorys");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: Caterorys/Delete/5
        public ActionResult Delete(int id)
        {
            var caterory = dbContext.Categories.FirstOrDefault(p => p.Id == id);
            if (caterory == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(caterory);
        }

        // POST: Caterorys/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var category1 = dbContext.Categories.FirstOrDefault(p => p.Id == id);
                    dbContext.Categories.Remove(category1);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "Caterorys");
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
