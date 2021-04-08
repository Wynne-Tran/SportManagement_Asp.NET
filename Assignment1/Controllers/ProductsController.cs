using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Assignment1.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsContext _db { get; set; }

        public ProductsController(ProductsContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (TempData["message"] != null)
            {
                ViewBag.message = TempData.Peek("message").ToString();

            }
            IEnumerable<Products> objList = _db.Products;
            return View(objList);
        }

        // GET - Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View("Edit", new Products());
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.Action = "Edit";
            var obj = _db.Products.Find(Id);
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["message"] = $"{obj.PName} was added";
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Create";
            return View("Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["message"] = $"{obj.PName} was edited";
                return RedirectToAction("Index");
            }
            ViewBag.Action = "Edit";
            return View("Edit");
        }

        // GET - Delete
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Products.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Remove(obj);
                _db.SaveChanges();
                TempData["message"] = $"{obj.PName} was deleted";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
