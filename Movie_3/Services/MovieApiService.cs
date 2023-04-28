using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Movie_3.Models;
using Movie_3.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movie_3.Services
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

        public async Task<MovieApiResponse> SearchByTitleAsync(string title)
        {
            title = title.ToLower();
            MovieApiResponse movies;
            if (!memoryCache.TryGetValue(title, out movies))
            {
                var result = await httpClient.GetStringAsync($"{movieApiOptions.BaseUrl}?s={title}&apikey={movieApiOptions.ApiKey}");
                movies = JsonConvert.DeserializeObject<MovieApiResponse>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(title, movies, cacheTime);
            }

            return movies;
        }

        public async Task<Search> SearchByIdAsync(string id)
        {
            Search movie;

            if (!memoryCache.TryGetValue(id, out movie))
            {
                var result = await httpClient.GetStringAsync($"{movieApiOptions.BaseUrl}?i={id}&apikey={movieApiOptions.ApiKey}");
                movie = JsonConvert.DeserializeObject<Search>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(id, movie, cacheTime);
            }

            return movie;
        }
    }
}
