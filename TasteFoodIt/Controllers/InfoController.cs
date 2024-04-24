using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class InfoController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult InfoList()
        {
            ViewBag.ınfo = context.Infos.Select(x => x.InfoId).Count();
            var values = context.Infos.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateInfo(Info ınfo)
        {
            context.Infos.Add(ınfo);
            context.SaveChanges();
            return RedirectToAction("InfoList");
        }
        public ActionResult DeleteInfo(int id)
        {
            var values = context.Infos.Find(id);
            context.Infos.Remove(values);
            context.SaveChanges();
            return RedirectToAction("InfoList");
        }

        [HttpGet]
        public ActionResult UpdateInfo(int id)
        {
            var values = context.Infos.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateInfo(Info ınfo)
        {
            var values = context.Infos.Find(ınfo.InfoId);
            values.Description = ınfo.Description;
            values.Title = ınfo.Title;
            values.ImageUrl = ınfo.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("InfoList");
        }
    }
}