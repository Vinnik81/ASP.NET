using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_3.Models;
using Movie_3.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_3.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IMovieApiService movieApiService;

        public HomeController(IMovieApiService movieApiService)
        {
            this.movieApiService = movieApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string title)
        {
            MovieApiResponse movies = null;
            if (title != null)
            {
                // MovieApiService apiService = new MovieApiService();
                movies = await movieApiService.SearchByTitleAsync(title);
                ViewBag.SearchTitle = title;
                ViewBag.Result = movies.Response;
            }

            return View(movies);
        }

        public async Task<IActionResult> Movie(string id)
        {
            Search movies = null;
            if (id != null)
            {
                // MovieApiService apiService = new MovieApiService();
                movies = await movieApiService.SearchByIdAsync(id);

            }

            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
