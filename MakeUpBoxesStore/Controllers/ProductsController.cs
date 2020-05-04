using AutoMapper;
using MakeUpBoxesStore.Db;
using MakeUpBoxesStore.Helpers;
using MakeUpBoxesStore.Models;
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
            return View(mapper.Map<ProductDetailsViewModel>(db.Products.FirstOrDefault(x=>x.Id==id)));
        }
    }
}