using Microsoft.AspNetCore.Mvc;
using Movie_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_2.Controllers
{
    public class TestController : Controller
    {
        private readonly IMovieApiService movieApiService;

        public TestController(IMovieApiService movieApiService)
        {
            this.movieApiService = movieApiService;
        }
        public IActionResult Index()
        {
            //movieApiService.Test();
            //movieApiService.Test();
            //movieApiService.Test();
            return View();
        }
    }
}
