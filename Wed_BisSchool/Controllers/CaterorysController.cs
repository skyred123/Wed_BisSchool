using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wed_BisSchool.Models;

namespace Wed_BisSchool.Controllers
{
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
            return View();
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
                var category1 = dbContext.Categories.FirstOrDefault(p => p.Id == id);
                dbContext.Categories.Remove(category1);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Caterorys");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
