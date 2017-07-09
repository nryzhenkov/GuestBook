using System;
using Microsoft.AspNetCore.Mvc;
using GuestBookApp.Models;
using GuestBookApp.DAL;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GuestBookApp.Controllers
{
    public class ShowController : Controller
    {
        private Dal dal;
        public ShowController(ArticleContext context)
        {
            dal = new Dal(context);
        }
        public IActionResult Index(int page = 1)
        {
            
            return View(dal.GetAllArticle(page));
        }
        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            dal.AddArticle(article);
            return RedirectToAction("Index");

        }
        public IActionResult Search(string text, bool key = false)  //поиск постов
        {

            return View(dal.Search(text,key));
        }
    }
}
