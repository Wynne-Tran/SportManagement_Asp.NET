using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1.Areas.Incident.Controllers
{
    [Area("Incidents")]
    public class HomeController : Controller
    {
        private ProductsContext _db { get; set; }

        public HomeController(ProductsContext db)
        {
            _db = db;
        }

        public void listTable()
        {
            ViewBag.Customers = _db.Customers.OrderBy(g => g.FirstName + g.LastName).ToList();
            ViewBag.Products = _db.Products.OrderBy(g => g.PName).ToList();
            ViewBag.Technicians = _db.Technicians.OrderBy(g => g.TName).ToList();
        }


        public IActionResult Index(string? Filter)
        {
            if(Filter == null)
            {
                ViewBag.nav = "home";
                TempData["Filter"] = "home";
                var movies = _db.Incidents
                    .Include(m => m.Customers)
                    .Include(g => g.Product)
                    .ToList();
                return View(movies);
            }
            else
            {
                switch (Filter)
                {
                    case "unassigned":
                        ViewBag.nav = "home";
                        TempData["Filter"] = "unassigned";
                        var unassigned = _db.Incidents
                       .Include(m => m.Customers)
                       .Include(g => g.Product)
                       .Where(g => g.TechniciansId == null)
                       .ToList();
                        return View("Index", unassigned);

                    case "opendate":
                        ViewBag.nav = "home";
                        TempData["Filter"] = "opendate";
                        var opendate = _db.Incidents
                     .Include(m => m.Customers)
                     .Include(g => g.Product)
                     .Where(g => g.DateClosed == null)
                     .ToList();
                        return View("Index", opendate);
                    default:
                        return View();
                };
            }
            
        }

        // GET - Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            listTable();
            return View("Edit");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.Action = "Edit";
            listTable();
            var obj = _db.Incidents.Find(Id);
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Incidents obj)
        {
            listTable();
            if (ModelState.IsValid)
            {
                _db.Incidents.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Create";
            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Incidents obj)
        {
            listTable();
            if (ModelState.IsValid)
            {
                _db.Incidents.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Edit";
            return View("Edit");
        }

        // GET - Delete
        
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var obj = _db.Incidents.Find(Id);
            ViewBag.Action = "Delete";
            listTable();
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Incidents obj)
        {
            _db.Incidents.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }

}
