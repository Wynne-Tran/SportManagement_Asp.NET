using Assignment1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class RegistrationsController : Controller
    {
        private ProductsContext _db { get; set; }

        public RegistrationsController(ProductsContext db)
        {
            _db = db;
        }
        public void listTable()
        {
            ViewBag.Technicians = _db.Technicians.ToList();
            ViewBag.Customers = _db.Customers.ToList();
            ViewBag.Products = _db.Products.ToList();
            ViewBag.Registrations = _db.Registrations.ToList();
        }
        public IActionResult GetCustomer()
        {
            listTable();
            return View();
        }

        [HttpGet]
        public IActionResult Index(Customers? cus, int? id)
        {
            if (cus.CustomersId == 0 && id == null)
            {
                ViewBag.error = "Please choice a customer !";
                listTable();
                return View("GetCustomer");
            } 
            int cusId = cus.CustomersId;
            if (cusId == 0)
            {
                cusId = (int)id;
            }
            // save CustomersId to the session
            HttpContext.Session.SetInt32("cusId", cusId);
            ViewBag.cusId = HttpContext.Session.GetInt32("cusId");
            listTable();
            if (cusId != 0)
            {
                var listPro = _db.Registrations
                 .Include(x => x.Products)
                 .Where(g => g.CustomersId == cusId)
                 .ToList();
                ViewBag.name = _db.Customers.Find(cusId).FullName;
                
                if (listPro.Count == 0)
                {
                    ViewBag.announcement = "There are no products registered for the selected user.";
                }
                return View("Index", listPro);
            }
            return View("GetCustomer");
        }


        [HttpPost]
        public IActionResult Index(Products getProduct)
        {
            if (getProduct.ProductsId != 0)
            {
                int? id = HttpContext.Session.GetInt32("cusId");
                Registrations reg = new Registrations();
                listTable();
                reg.CustomersId = (int)id;
                reg.ProductsId = getProduct.ProductsId;
                _db.Registrations.Add(reg);            
                _db.SaveChanges();
                return RedirectToAction("Index", reg.Customers);
            }
            return View("Index");
        }
  
        [HttpGet]
        public IActionResult Delete([FromRoute] string id)
        {
            ViewBag.RegistrationsId = Convert.ToInt32(id);
            int? cusId = HttpContext.Session.GetInt32("cusId");
            var reg = _db.Registrations
                        .Include(x => x.Customers)
                        .Include(x => x.Products)
                        .Where(x => x.CustomersId == cusId);
             reg = reg.Where(x => x.ProductsId == Convert.ToInt32(id));
            Registrations regDel = _db.Registrations.Find(Convert.ToInt32(id));
            _db.Registrations.Remove(regDel);
            _db.SaveChanges();
            return RedirectToAction("Index", _db.Customers.Find(cusId));

        }

    }


}

