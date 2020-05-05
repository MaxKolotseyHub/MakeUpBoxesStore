using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext db;
        public HomeController()
        {
            db = new MyDbContext();
        }
        public ActionResult Index()
        {
            return RedirectToAction("Selected","Category", new { id=0});
        }
        public ActionResult GetNav()
        {
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Boxes = BoxesCart.GetInstance().GetBoxes();
            return PartialView();
        }
    }
}