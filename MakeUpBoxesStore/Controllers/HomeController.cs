using MakeUpBoxesStore.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetNav()
        {
            using (MyDbContext db = new MyDbContext())
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Boxes = db.Boxes.ToList();
            }
                return PartialView();
        }
    }
}