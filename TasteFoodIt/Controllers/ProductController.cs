using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ProductController : Controller
    {
        TasteContext context = new TasteContext();
        [Authorize]
        public ActionResult ProductList()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            product.IsActive = true;
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = context.Products.Find(id);
            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            
            var values = context.Products.Find(product.ProductId);
            values.ProductName = product.ProductName;
            values.Description = product.Description;
            values.CategoryId = product.CategoryId;
            values.Price = product.Price;
            values.ImageUrl = product.ImageUrl;
            product.IsActive = true;
            context.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}