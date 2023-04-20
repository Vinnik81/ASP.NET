using Microsoft.Extensions.Options;
using Movie_2.Models;
using Movie_2.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movie_2.Services
{
    public class MovieApiService : IMovieApiService
    {
        //public string BaseUrl { get; }
        //public string ApiKey { get; }
        private MovieApiOptions movieApiOptions;
        public int number = 0;

        private HttpClient httpClient;

        public MovieApiService(IHttpClientFactory httpClientFactory, IOptions<MovieApiOptions> options)
        {
            //BaseUrl = "https://omdbapi.com/";
            //ApiKey = "5b9b7798";
            Console.WriteLine("Hello version " + number++);
            movieApiOptions = options.Value;
            //BaseUrl = options.Value.BaseUrl;
            //ApiKey = options.Value.ApiKey;
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<MovieApiResponse> SearchByTitleAsync(string title)
        {
            var result = await httpClient.GetStringAsync($"{movieApiOptions.BaseUrl}?s={title}&apikey={movieApiOptions.ApiKey}");
            MovieApiResponse movies = JsonConvert.DeserializeObject<MovieApiResponse>(result);
            return movies;
        }

        public async Task<Search> SearchByIdAsync(string id)
        {
            var result = await httpClient.GetStringAsync($"{movieApiOptions.BaseUrl}?i={id}&apikey={movieApiOptions.ApiKey}");
            Search movies = JsonConvert.DeserializeObject<Search>(result);
            return movies;
        }

        //public void Test() 
        //{
        //    Console.WriteLine("Hello version " + number++);
        //}
    }
}
