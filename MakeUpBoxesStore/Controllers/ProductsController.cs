using AutoMapper;
using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Helpers;
using MakeUpBoxesStore.Models;
using MakeUpBoxesStore.Models.DbEntities;
using MakeUpBoxesStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MakeUpBoxesStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyDbContext db;
        private readonly Mapper mapper;

        public ProductsController()
        {
            db = new MyDbContext();
            mapper = AutoMapperConfig.GetMapper();
        }
        // GET: Products
        public ActionResult Details(int id)
        {
            ViewBag.Boxes = BoxesCart.GetInstance().GetBoxes();
            return View(mapper.Map<ProductDetailsViewModel>(db.Products.FirstOrDefault(x => x.Id == id)));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.Images = new List<Image>();
            product.Producer = new Producer();
            product.Categories = new List<Category>();
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Products");
        }
        public ActionResult Index()
        {
            return View(mapper.Map<List<ProductListViewModel>>(db.Products.ToList()));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            var categories = db.Categories.ToList();
            foreach (var cat in product.Categories)
            {
                categories.Remove(cat);
            }
            ViewBag.Categories = categories;
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            return RedirectToAction("Index", "Products");
        }
        public ActionResult RemoveFromCategory(int categoryId, int productId)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                var category = product.Categories.FirstOrDefault(x => x.Id == categoryId);
                if (category != null)
                {
                    product.Categories.Remove(category);
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Edit", new { id = productId });
        }
        public ActionResult AddToCategory(int categoryId, int productId)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                var category = db.Categories.FirstOrDefault(x => x.Id == categoryId);
                if (category != null)
                {
                    product.Categories.Add(category);
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Edit", new { id = productId });
        }
        public ActionResult RemoveImage(int productId, int imageId)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                var image = product.Images.FirstOrDefault(x => x.Id == imageId);
                if (image != null)
                {
                    db.Images.Remove(image);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Edit", new { id = productId });
        }
        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == productId);
            if (product != null)
            {
                product.Images.Add(new Image() { Url = url });

                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new { id = productId });
        }
    }
}   