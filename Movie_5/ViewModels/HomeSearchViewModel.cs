using Movie_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_5.ViewModels
{
    public class HomeSearchViewModel
    {
        public IEnumerable<Cinema> Cinemas { get; set; }
        public string Title { get; set; }
        public int TotalResults { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageCount { get; set; }
        public string Response { get; set; }
    }
}
