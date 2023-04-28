using Movie_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_3.Services
{
   public interface IMovieApiService
    {
        Task<MovieApiResponse> SearchByTitleAsync(string title);
        Task<Search> SearchByIdAsync(string id);
    }
}
