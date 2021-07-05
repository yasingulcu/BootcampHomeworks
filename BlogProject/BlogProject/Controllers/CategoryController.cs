using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Context _context = null;

        public CategoryController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categoryvalues = _context.Categories.ToList();
            return View(categoryvalues);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category p)
        {
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
