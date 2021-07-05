using FoodProject.Data;
using FoodProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult GetList()
        {
            var result = _applicationDbContext.Categories.ToList();
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Add(Category model)
        {
            _applicationDbContext.Categories.Add(model);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("GetList");
        }
    }
}
