using Movie_4.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_4.Services
{
    public class RecentMovieStorage : IRecentMovieStorage
    {
        public ConcurrentQueue<Cinema> Cinemas { get; set; } = new ConcurrentQueue<Cinema>();

        public void Add(Cinema cinema)
        {
            if (!Cinemas.Contains(cinema))
            {
                Cinemas.Enqueue(cinema);
            }
            
            if (Cinemas.Count > 4)
            {
                Cinemas.TryDequeue(out Cinema trash);
            }
        }

        public IEnumerable<Cinema> GetCinemas()
        {
           return Cinemas.Take(4);
        }
    }
}
