using Movie_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_6.Services
{
   public interface IMovieApiService
    {
        Task<MovieApiResponse> SearchByTitleAsync(string title, int page);
        Task<Cinema> SearchByIdAsync(string id);
    }
}
