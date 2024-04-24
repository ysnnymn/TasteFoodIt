using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AddressController : Controller
    {

        TasteContext context = new TasteContext();
        public ActionResult AddressesList()
        {
            ViewBag.addreses = context.Addresses.Select(x => x.AddressId).Count();
            var values = context.Addresses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatedAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatedAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
            return RedirectToAction("AddressesList");

        }

        [HttpGet]
        public ActionResult UpdatedAddress(int id)
        {
            var values = context.Addresses.Find(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdatedAddress(Address address)
        {
            var values = context.Addresses.Find(address.AddressId);
            values.Description = address.Description;
            values.Phone = address.Phone;
            values.Email = address.Email;
            context.SaveChanges();
            return RedirectToAction("AddressesList");

        }
        public ActionResult DeleteAddress(int id)
        {
            var values = context.Addresses.Find(id);
            context.Addresses.Remove(values);
            context.SaveChanges();
            return RedirectToAction("AddressesList");
        }

    }
}