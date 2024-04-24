using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
   
        public ActionResult AboutList()
        {
            ViewBag.about = context.Abouts.Select(x => x.AboutId).Count();
            var values = context.Abouts.ToList();
            return View(values);
        }
       [HttpGet]
       public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.Abouts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("AboutList");


        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var values = context.Abouts.Find(about.AboutId);
            values.Description = about.Description;
            values.Title = about.Title;
            values.ImageUrl = about.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}