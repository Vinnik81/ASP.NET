using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Movie_4.Models;
using Movie_4.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movie_4.Services
{
    public class MovieApiService: IMovieApiService
    {
        private MovieApiOptions movieApiOptions;
        public int number = 0;

        private HttpClient httpClient;
        private readonly IMemoryCache memoryCache;

        public MovieApiService(IHttpClientFactory httpClientFactory, IOptions<MovieApiOptions> options, IMemoryCache memoryCache)
        {
            //BaseUrl = "https://omdbapi.com/";
            //ApiKey = "5b9b7798";
            Console.WriteLine("Hello version " + number++);
            movieApiOptions = options.Value;
            //BaseUrl = options.Value.BaseUrl;
            //ApiKey = options.Value.ApiKey;
            httpClient = httpClientFactory.CreateClient();
            this.memoryCache = memoryCache;
        }

        public async Task<MovieApiResponse> SearchByTitleAsync(string title, int page = 1)
        {
            title = title.ToLower();
            MovieApiResponse movies;
            if (!memoryCache.TryGetValue($"{title} {page}", out movies))
            {
                var result = await httpClient.GetStringAsync($"{movieApiOptions.BaseUrl}?s={title}&apikey={movieApiOptions.ApiKey}&page={page}");
                movies = JsonConvert.DeserializeObject<MovieApiResponse>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set($"{title} {page}", movies, cacheTime);
            }

            return movies;
        }

        public async Task<Cinema> SearchByIdAsync(string id)
        {
            Cinema movie;

            if (!memoryCache.TryGetValue(id, out movie))
            {
                var result = await httpClient.GetStringAsync($"{movieApiOptions.BaseUrl}?i={id}&apikey={movieApiOptions.ApiKey}");
                movie = JsonConvert.DeserializeObject<Cinema>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(id, movie, cacheTime);
            }

            return movie;
        }
    }
}
