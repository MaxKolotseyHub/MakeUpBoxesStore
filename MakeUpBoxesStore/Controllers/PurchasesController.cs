using AutoMapper;
using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Helpers;
using MakeUpBoxesStore.Models;
using MakeUpBoxesStore.Models.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly MyDbContext db;
        private readonly Mapper mapper;
        public PurchasesController()
        {
            db = new MyDbContext();
            mapper = AutoMapperConfig.GetMapper();
        }
        // GET: Purchases
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.BoxId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client, int boxId)
        {
            if (ModelState.IsValid)
            {
                Purchase purchase = new Purchase();
                purchase.Client = client;
                var box = BoxesCart.GetInstance().GetBoxes().FirstOrDefault(x => x.Id == boxId);
                if (box != null)
                {
                    foreach (var product in box.ProductCount)
                    {
                        var purchProd = mapper.Map<PurchaseProduct>(product.Key);
                        purchProd.Count = product.Value;
                        purchase.Products.Add(purchProd);

                        var p = db.Products.FirstOrDefault(x=>x.Id == product.Key.Id);
                        p.Count -= product.Value;
                        db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                    }
                    purchase.State = "Отправлеено";
                    db.Purchases.Add(purchase);
                    db.SaveChanges();
                }
                BoxesCart.GetInstance().Delete(box.Id);

                return RedirectToAction("Index", "Home");
            }
            else return View(client);
        }

    }
}