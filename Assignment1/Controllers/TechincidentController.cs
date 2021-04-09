using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Assignment1.Controllers
{
    public class TechincidentController : Controller
    {
        private ProductsContext _db { get; set; }

        public TechincidentController(ProductsContext db)
        {
            _db = db;
        }

        public void listTable()
        {
            ViewBag.Technicians = _db.Technicians.ToList();
            ViewBag.Customers = _db.Customers.ToList();
            ViewBag.Products = _db.Products.ToList();
        }

        public IActionResult Get()
        {
            ViewBag.Technicians = _db.Technicians.ToList();
            return View("Get");
        }

        [HttpGet]
        public IActionResult List(Technicians? tech, int? id)
        {
            if (tech.TechniciansId == 0 && id == null)
            {
                listTable();
                ViewBag.error = "Please choice a technician !";
                return View("Get");
            }
            int Id = tech.TechniciansId;
            if (Id == 0)
            {
                Id = (int)id;
            }
            // save TechiniciansId to the session
            HttpContext.Session.SetInt32("TechId", Id);
            listTable();
            if (Id != 0)
            {
                var listTech = _db.Incidents
                 .Where(g => g.TechniciansId == Id)
                 .ToList();
                ViewBag.name = _db.Technicians.Find(Id).TName;
                if (listTech.Count == 0)
                {
                    ViewBag.announcement = "Information was not found...";
                }
                return View("List", listTech);
            }
            ViewBag.error = "Please choice a technician !";
            return View("Get");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            listTable();
            ViewBag.Incidents = _db.Incidents.ToList();
            var obj = _db.Incidents.Find(id);
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Incidents obj)
        {
            if (ModelState.IsValid)
            {
                _db.Incidents.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("List", obj);
            }
            // call session for return List page
            //read session
            int? id = HttpContext.Session.GetInt32("TechId");
            return View("Edit", obj);
        }

    }
}
