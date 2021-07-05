using FoodProject.Data;
using FoodProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MenuController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult GetList()
        {
            var result = _applicationDbContext.Menus.ToList();
            return View(result);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Add(Menu model)
        {
            _applicationDbContext.Menus.Add(model);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("GetList");
        }
    }
}
