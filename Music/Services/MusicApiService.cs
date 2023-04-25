using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Music.Models;
using Music.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Services
{
    public class MusicApiService : IMusicApiService
    {
        private MusicApiOptions musicApiOptions;
        public int number = 0;

        private HttpClient httpClient;
        private readonly IMemoryCache memoryCache;

        public MusicApiService(IHttpClientFactory httpClientFactory, IOptions<MusicApiOptions> options, IMemoryCache memoryCache)
        {
            Console.WriteLine("Music version " + number++);
            musicApiOptions = options.Value;
            httpClient = httpClientFactory.CreateClient();
            this.memoryCache = memoryCache;
        }

        public async Task<MusicApiResponse> SearchByNameAsync(string name)
        {
            name = name.ToLower();
            MusicApiResponse musics;
            if (!memoryCache.TryGetValue(name, out musics))
            {
                var result = await httpClient.GetStringAsync($"{musicApiOptions.BaseUrl}?method=artist.search&artist={name}&api_key={musicApiOptions.Apikey}&format=json");
                musics = JsonConvert.DeserializeObject<MusicApiResponse>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(name, musics, cacheTime);
            }
            return musics;
        }
    }
}
