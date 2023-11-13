using Microsoft.AspNetCore.Mvc;
using ne_izlesek_Web_App.Models;
using ne_izlesek_Web_App.Models.Context;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using ne_izlesek_Web_App.Models.Entities;
using ne_izlesek_Web_App.Models.MoviesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing.Printing;

namespace ne_izlesek_Web_App.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Movies(int? page)
        {
            int pageSize = 9;
            int pageNumber = page ?? 1;
            var model = new MovieIndexViewModel
            {



                Filmler = db.Filmler.OrderByDescending(f => f.MovieRating)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList(),
                Film = new Film(),
                PageSize = pageSize,
                TotalRecords = db.Filmler.Count()
            };
            return View(model);
            
            //var model = new MovieIndexViewModel
            //{
            //    Filmler = db.Filmler.OrderByDescending(f => f.MovieRating)                                  
            //                          .ToList(),
            //    Film = new Film(), // Eğer bu kısım gerekiyorsa, yeni bir film eklemek için kullanılabilir.
            //};

            //return View(model);
        }


        public IActionResult Series()
        {

            var model = new SerieIndexViewModel
            {
                Diziler = db.Diziler.OrderByDescending(f => f.SerieRating)
                                      .ToList(),
                Dizi = new Dizi(), // Eğer bu kısım gerekiyorsa, yeni bir film eklemek için kullanılabilir.
            };

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}