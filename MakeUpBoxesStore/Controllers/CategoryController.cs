using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext db;
        public CategoryController()
        {
            db = new MyDbContext();
        }
        // GET: Category
        public ActionResult Selected(int id)
        {
            if(id==0)
            return View(db.Products.ToList());
            else
            return View(db.Categories.FirstOrDefault(x => x.Id == id).Products.ToList());
        }
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        public ActionResult Delete(int id)
        {
            var cat = db.Categories.FirstOrDefault(x=>x.Id==id);
            if (cat != null)
            {
                db.Categories.Remove(cat);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = db.Categories.FirstOrDefault(x => x.Id == id);
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            return RedirectToAction("Index");
        }

    }
}