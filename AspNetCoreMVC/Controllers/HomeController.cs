using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVC.Models;
using AutoMapper;

namespace AspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var autor = new AuthorEntity() { Id = 1, Age = 30, Books = new List<BookEntity>() { new BookEntity { Id = 1, Edition = 1, Pages = 1424, Subtitle= "LAS AVENTURAS DE DON QUIJOTE DE LA MANCHA", Title= "DON QUIJOTE DE LA MANCHA" } }, Name = "Miguel de Cervantes" };

            var autorModel = Mapper.Map<AuthorEntity, AuthorModel>(autor);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
