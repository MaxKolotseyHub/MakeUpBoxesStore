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
        public ActionResult Index(int id)
        {
            if(id==0)
            return View(db.Products.ToList());
            else
            return View(db.Categories.FirstOrDefault(x => x.Id == id).Products.ToList());
        }
    }
}