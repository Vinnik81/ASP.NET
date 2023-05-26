using Movie_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_6.Services
{
   public interface IRecentMovieStorage
    {
        IEnumerable<Cinema> GetCinemas();
        void Add(Cinema cinema);
    }
}
