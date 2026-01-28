using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace crud.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationsDbContext context = new ApplicationsDbContext();
        public IActionResult Index()
        {
            var products = context.Products;
            return View("Index", products);
        }
        public IActionResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View("Details", product);
        }
        public IActionResult Create()
        {
            return View("Create",new Product());
        }
        public IActionResult Store(Product request)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", request);

        }
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            return View("Edit", product);
        }
        public IActionResult Update(Product request)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", request);
        }
    }
}