using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        readonly string apiKey = "5b9b7798";
        readonly string baseUrl = "https://omdbapi.com/";

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
                HttpClient httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync($"{baseUrl}?s={title}&apikey={apiKey}");
                movies = JsonConvert.DeserializeObject<MovieApiResponse>(result);
                ViewBag.SearchTitle = title;
                ViewBag.Result = result;
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
