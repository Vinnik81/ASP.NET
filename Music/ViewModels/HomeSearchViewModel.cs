using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.ViewModels
{
    public class HomeSearchViewModel
    {
        public IEnumerable<Datum> Musics { get; set; }
        public string Title { get; set; }
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageCount { get; set; }
        public string Next { get; set; }
    }
}
