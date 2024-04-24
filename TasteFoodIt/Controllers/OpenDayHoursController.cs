using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
namespace TasteFoodIt.Controllers
{
    public class OpenDayHoursController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult OpenDayHoursList()
        {
            ViewBag.open = context.OpenDayHours.Count();
            var value = context.OpenDayHours.ToList();
            return View(value);
        }
        public ActionResult DeleteOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            context.OpenDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenDayHoursList");
        }
        [HttpGet]
        public ActionResult CreateOpenDayHour()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateOpenDayHour(OpenDayHour openDayHour)
        {
            context.OpenDayHours.Add(openDayHour);
            context.SaveChanges();
            return RedirectToAction("OpenDayHoursList");

        }
        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            var values = context.OpenDayHours.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour openDayHour)
        {
            var values = context.OpenDayHours.Find(openDayHour.OpenDayHourId);
            values.DayName = openDayHour.DayName;
            values.OpenHourRange = openDayHour.OpenHourRange;
            context.SaveChanges();
            return RedirectToAction("OpenDayHoursList");
        }
    }
}