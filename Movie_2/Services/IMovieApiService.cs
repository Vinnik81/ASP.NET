using Movie_2.Models;
using System.Threading.Tasks;

namespace Movie_2.Services
{
    public interface IMovieApiService
    {
        Task<MovieApiResponse> SearchByTitleAsync(string title);
        Task<Search> SearchByIdAsync(string id);
        //void Test();
    }
}