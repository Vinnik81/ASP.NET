using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Music.Models;
using Music.Services;
using Music.ViewModels;
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
        private readonly IRecentMusicStorage recentMusicStorage;

        public HomeController(IMusicApiService musicApiService, IRecentMusicStorage recentMusicStorage)
        {
            this.musicApiService = musicApiService;
            this.recentMusicStorage = recentMusicStorage;
        }

        public IActionResult Index()
        {
            return View(recentMusicStorage.GetMusics());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string title, int page = 1)
        {
            HomeSearchViewModel results = null;
            if (title != null)
            {
                MusicApiResponse musics = await musicApiService.SearchByNameAsync(title, page);
                results = new HomeSearchViewModel
                {
                    Musics = musics.data,
                    CurrentPage = page,
                    Title = title,
                    TotalPages = (int)Math.Ceiling(musics.total / 10.0),
                    PageCount = 4,
                    Total = musics.total,
                    Next = musics.next
                };
                //ViewBag.SearchName = title;
                //ViewBag.Results = musics.data;
                
            }
            return View(results);
        }

        public async Task<ActionResult> SearchResult(string title, int page = 1)
        {
            MusicApiResponse musics = await musicApiService.SearchByNameAsync(title, page);
            return PartialView("_MusicListPartial", musics.data);
        }

        public async Task<IActionResult> Music(int id)
        {
            MusicApiAlbum musics = null;
            if (id != null)
            {
                musics = await musicApiService.SearchByTrackAsync(id);
                recentMusicStorage.Add(musics.tracks.data[0]);
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
