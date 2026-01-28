using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace crud.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationsDbContext context = new ApplicationsDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories;
            return View("Index", categories);
        }
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            category.Products = context.Products.Where(p => p.CategoryId == id).ToList();
            return View("Details", category);
        }
        public IActionResult Create()
        {
            return View("Create",new Category());
        }
        public IActionResult Store(Category request)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", request);
        }
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            return View("Edit",category);
        }
        public IActionResult Update(Category request)
        {
            if(ModelState.IsValid)
            {
                context.Categories.Update(request);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit",request);
        } 
    }
}