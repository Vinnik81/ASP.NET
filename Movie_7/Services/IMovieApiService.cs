using Movie_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_7.Services
{
   public interface IMovieApiService
    {
        Task<MovieApiResponse> SearchByTitleAsync(string title, int page);
        Task<Cinema> SearchByIdAsync(string id);
    }
}
