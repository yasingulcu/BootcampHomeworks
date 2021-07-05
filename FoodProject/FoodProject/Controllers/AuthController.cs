using FoodProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signinManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signinManager, UserManager<User> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }

         [HttpGet]

        public  IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(string userName, string password)
        {
            var result = await _signinManager.PasswordSignInAsync(userName, password, false, false);

            if (!result.Succeeded) return RedirectToAction("Login");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(UserViewModel model)
        {
            var user = new User();

            var result= await _userManager.CreateAsync(user , model.Password);
            return View();
        }
    }
}
