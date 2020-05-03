using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    public class BoxesController : Controller
    {
        private readonly MyDbContext db;
        public BoxesController()
        {
            db = new MyDbContext();
        }
        // GET: Boxes
        [HttpGet]
        public ActionResult Index(int id)
        {
            var box = BoxesCart.GetInstance().Boxes.FirstOrDefault(x => x.Id == id);
            ViewBag.Products = db.Products.Where(x => box.ProductCount.Keys.Contains(x.Id)).ToList();

            return View(BoxesCart.GetInstance().Boxes.FirstOrDefault(x => x.Id == id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Box box)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", box);
            }

            if(!BoxesCart.GetInstance().Add(box))
            {
                return View("Create", box);
            }
            return RedirectToAction("Index","Home");
        }
    }
}