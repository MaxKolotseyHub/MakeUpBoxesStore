using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    [Authorize]
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
            return View(BoxesCart.GetInstance().GetBoxes().FirstOrDefault(x => x.Id == id));
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
        [HttpPost]
        public ActionResult AddProduct(int boxId, int productId, int productCount)
        {
            var box = BoxesCart.GetInstance().GetBoxes().FirstOrDefault(x => x.Id == boxId);
            if (box != null)
            {
                box.ProductCount.Add(db.Products.FirstOrDefault(x=>x.Id== productId), productCount);
            }

            var categoryId = db.Products.FirstOrDefault(x => x.Id == productId).Categories.Select(x=>x.Id).First();
            return RedirectToAction("Selected", "Category", new { id = categoryId });
        }
    }
}