using BlogProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly Context _context;

        public CommentController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var commentvalues = _context.Comments.ToList();
            return View(commentvalues);
        }
        public IActionResult GetList(int id)
        {
            var commentvalues = _context.Comments.Where(x => x.ArticleId == id).ToList();
            return View(commentvalues);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> vuser = (from x in _context.Users.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.UserName,
                                              Value = x.UserId.ToString()
                                          }).ToList();
            ViewBag.vlc1 = vuser;
            List<SelectListItem> valuecomment = (from x in _context.Articles.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ArticleName,
                                                     Value = x.ArticleId.ToString()
                                                 }).ToList();
            ViewBag.vlc = valuecomment;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Comment p)
        {
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
