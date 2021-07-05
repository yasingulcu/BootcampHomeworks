using FoodProject.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RestaurantController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult GetList()
        {
            var result = _applicationDbContext.Restaurants.ToList();
            return View(result);
        }
    }
}
