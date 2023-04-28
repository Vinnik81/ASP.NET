using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Models;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IMusicApiService musicApiService;

        public HomeController(IMusicApiService musicApiService)
        {
            this.musicApiService = musicApiService;
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
            MusicApiResponse musics = null;
            if (title != null)
            {
                musics = await musicApiService.SearchByNameAsync(title);
                ViewBag.SearchName = title;
                ViewBag.Results = musics.data;
                
            }
            return View(musics);
        }

        public async Task<IActionResult> Music(string title)
        {
            MusicApiResponse musics = null;
            if (title != null)
            {
                musics = await musicApiService.SearchByTrackAsync(title);
            }
            return View(musics);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
