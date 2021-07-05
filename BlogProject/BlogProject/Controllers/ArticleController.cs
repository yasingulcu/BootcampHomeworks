using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class ArticleController : Controller
    {
        private readonly Context _context = null;

        public ArticleController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var articlelist = _context.Articles.ToList();
            return View(articlelist);
        }
        public IActionResult GetList(int id)
        {
            var articlevalues = _context.Articles.Where(x => x.CategoryId == id).ToList();

            return View(articlevalues);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Article p)
        {
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
