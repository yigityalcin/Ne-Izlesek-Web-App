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
using RestSharp;
using System.Text.Json;

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

        public async Task<IActionResult> MoviesAsync(int? page)
        {

            int pageSize = 9;
            int pageNumber = page ?? 1;
            //var model = new MovieIndexViewModel
            //{



            //    Filmler = db.Filmler.OrderByDescending(f => f.MovieRating)
            //                      .Skip((pageNumber - 1) * pageSize)
            //                      .Take(pageSize)
            //                      .ToList(),
            //    Film = new Film(),
            //    PageSize = pageSize,
            //    TotalRecords = db.Filmler.Count(),
            //    CurrentPage = pageNumber  // Set the CurrentPage property

            //};
            var model = await GetMovieService(pageNumber);

            return View(model);

            //var model = new MovieIndexViewModel
            //{
            //    Filmler = db.Filmler.OrderByDescending(f => f.MovieRating)                                  
            //                          .ToList(),
            //    Film = new Film(), // Eğer bu kısım gerekiyorsa, yeni bir film eklemek için kullanılabilir.
            //};

            //return View(model);
        }

        private async Task<MovieIndexViewModel> GetMovieService(int? page)
        {
            var apiKey = "d821552a352a5b41a205909d81ec8df7"; // The Movie Database API key
            var apiUrl = $"https://api.themoviedb.org/3/discover/movie?api_key={apiKey}&include_adult=false&include_video=false&language=en-US&page={page}&sort_by=popularity.desc";

            var options = new RestClientOptions(apiUrl);
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");

            var response = await client.GetAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // JSON verisini deserialize etme
                MovieApiResponse movieApiResponse = new MovieApiResponse { };
                movieApiResponse = JsonSerializer.Deserialize<MovieApiResponse>(response.Content);

                // Film listesine erişme
                List<ApiMovie>? results = movieApiResponse?.Results;
                List<ApiMovie> films = results;

                // Films listesini kullanma
                if (films != null)
                {
                    var model = new MovieIndexViewModel
                    {
                        Movies = films,
                        PageSize = movieApiResponse.TotalPages,
                        TotalRecords = movieApiResponse.TotalResults,
                        CurrentPage = movieApiResponse.Page,
                        TotalPages = movieApiResponse.TotalPages,
                        
                    };

                    foreach (var film in films)
                    {
                        film.ReleaseDate = DateTime.Parse(film.ReleaseDate).ToString("yyyy-MM-dd");
                        Console.WriteLine($"Film Title: {film.Adult}, Release Date: {film.ReleaseDate}");
                    }

                    return model;
                }
                else
                {
                    Console.WriteLine("API yanıtı geçerli bir film listesi içermiyordu.");
                    return new MovieIndexViewModel();
                }
            }
            else
            {
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return new MovieIndexViewModel(); // Burada bir değer döndürmeyi ekledik
            }
        }
    

        public IActionResult Series(int? page)
        {

            int pageSize = 9;
            int pageNumber = page ?? 1;
            var model = new SerieIndexViewModel
            {



                Diziler = db.Diziler.OrderByDescending(f => f.SerieRating)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList(),
                Dizi = new Dizi(),
                PageSize = pageSize,
                TotalRecords = db.Diziler.Count(),
                CurrentPage = pageNumber  // Set the CurrentPage property

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