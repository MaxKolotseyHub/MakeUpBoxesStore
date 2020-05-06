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
            return View(db.Purchases.ToList());
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

                        var p = db.Products.FirstOrDefault(x => x.Id == product.Key.Id);
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

        public ActionResult Delete(int id)
        {
            var p = db.Purchases.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                db.Purchases.Remove(p);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var p = db.Purchases.FirstOrDefault(x => x.Id == id);

            return View(p);
        }
        [HttpPost]
        public ActionResult Client(Client client, int id)
        {
            db.Entry(client).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = id });
        }
        [HttpPost]
        public ActionResult Status(string state, int id)
        {
            var p = db.Purchases.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.State = state;
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new { id = id });
        }
    }
}