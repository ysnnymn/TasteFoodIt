using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
namespace TasteFoodIt.Controllers
{
    public class ChefController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ChefList()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }
        public ActionResult DeleteChef(int id)
        {
            var values = context.Chefs.Find(id);
            context.Chefs.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult CreateChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateChef(Chef chef)
        {
            context.Chefs.Add(chef);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var values = context.Chefs.Find(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            var values = context.Chefs.Find(chef.ChefId);
            values.Description = chef.Description;
            values.ImageUrl = chef.ImageUrl;
            values.Title = chef.Title;
            values.NameSurname = chef.NameSurname;
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}