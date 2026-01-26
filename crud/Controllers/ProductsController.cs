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
        public ViewResult Index()
        {
            var products = context.Products;
            return View("Index",products);
        }
        public ViewResult Details(int id)
        {
            var product = context.Products.Find(id);
            return View("Details",product);
        }
        public ViewResult Create()
        {
            return View("Create"); 
        }
        public ViewResult Store(Product request)
        {
            context.Products.Add(request);
            context.SaveChanges();
            return View("Create");
        }
        public ViewResult Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            var products = context.Products;
            return View("Index",products);
        }
    }
}