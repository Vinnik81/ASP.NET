using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_6.Models;
using Movie_6.Services;
using Movie_6.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_6.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IMovieApiService movieApiService;
        private readonly IRecentMovieStorage recentMovieStorage;

        public HomeController(IMovieApiService movieApiService, IRecentMovieStorage recentMovieStorage)
        {
            this.movieApiService = movieApiService;
            this.recentMovieStorage = recentMovieStorage;
        }

        public IActionResult Index()
        {
            return View(recentMovieStorage.GetCinemas());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public async Task<IActionResult> Search(string title, int page = 1)
        //{
        //    MovieApiResponse movies = null;
        //    if (title != null)
        //    {
        //        // MovieApiService apiService = new MovieApiService();
        //        movies = await movieApiService.SearchByTitleAsync(title, page);

        //        ViewBag.TotalPages = (int)Math.Ceiling(int.Parse(movies.TotalResults) / 10.0);
        //        ViewBag.SearchTitle = title;
        //        ViewBag.CurrentPage = page;
        //        ViewBag.PageSize = 5;
        //        ViewBag.Result = movies.Response;
        //    }

        //    return View(movies);
        //}

        public async Task<IActionResult> Search(string title, int page = 1)
        {
            HomeSearchViewModel results = null;
            if (title != null)
            {
                // MovieApiService apiService = new MovieApiService();
                MovieApiResponse movies = await movieApiService.SearchByTitleAsync(title, page);

                results = new HomeSearchViewModel
                {
                    Cinemas = movies.Movies,
                    CurrentPage = page,
                    Title = title,
                    TotalPages = (int)Math.Ceiling(int.Parse(movies.TotalResults) / 10.0),
                    PageCount = 4,
                    TotalResults = int.Parse(movies.TotalResults),
                    Response = movies.Response
                };
            }

            return View(results);
        }

        public async Task<IActionResult> SearchResult(string title, int page = 1)
        {
            MovieApiResponse movies = await movieApiService.SearchByTitleAsync(title, page);
            return PartialView("_MovieListPartial", movies.Movies);
        }

        public async Task<IActionResult> Movie(string id)
        {
            Cinema movies = null;
            if (id != null)
            {
                // MovieApiService apiService = new MovieApiService();
                movies = await movieApiService.SearchByIdAsync(id);
                recentMovieStorage.Add(movies);
            }

            return View(movies);
        }

        public async Task<IActionResult> MovieModal(string id)
        {
            Cinema movies = null;
            if (id != null)
            {
                movies = await movieApiService.SearchByIdAsync(id);
            }

            return PartialView("_MovieModalPartial", movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
