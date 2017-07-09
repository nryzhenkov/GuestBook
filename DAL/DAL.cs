using GuestBookApp.Models;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace GuestBookApp.DAL
{
    public class Dal
    {
        ArticleContext db;
        public Dal(ArticleContext context)
        {
            db = context;
        }

        public void AddArticle(Article article)
        {
            article.Date = DateTime.UtcNow;
            article.Date = article.Date.Add(new TimeSpan(3,0,0));
            db.Articles.Add(article);
            db.SaveChanges();
        }
        public IndexViewModel GetAllArticle(int page)
        {
            const int pageSize = 5;
            IQueryable<Article> source = db.Articles.OrderByDescending(u => u.Date);
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Articles = items
            };
            return viewModel;
        } 
        public List<Article> Search(string text, bool key)
        {
            Regex Etalon = new Regex(@".*" + text + @".*", RegexOptions.IgnoreCase);
            IQueryable<Article> source;
            List<Article> save = new List<Article>();
            if (key)
                source = db.Articles.Where(b => Etalon.IsMatch(b.Theme));
            else
                source = db.Articles.Where(a => Etalon.IsMatch(a.Text));
            save = source.ToList();
            /*foreach(var Art in db.Articles)
            {
            if (string.Compare(key, "true") == 0)  //поиск по теме
            {
                  if (Etalon.IsMatch(Art.Theme))
                  {
                    save.Add(Art);
                 }
            }
            else                                    //поиск по теме
            {
                if (Etalon.IsMatch(Art.Text))
                    { 
                   save.Add(Art);
                }
             }s
            }*/
            return save;
        }
    }
}
