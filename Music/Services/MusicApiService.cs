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

        public async Task<MusicApiResponse> SearchByNameAsync(string title, int page = 1)
        {
            title = title.ToLower();
            MusicApiResponse musics;
            if (!memoryCache.TryGetValue($"{title} {page}", out musics))
            {
                var result = await httpClient.GetStringAsync($"{musicApiOptions.BaseUrl}search?q={title}&index={page * 10}&limit=12");
                musics = JsonConvert.DeserializeObject<MusicApiResponse>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set($"{title} {page}", musics, cacheTime);
            }
            return musics;
        }

        public async Task<MusicApiAlbum> SearchByTrackAsync(int id)
        {
            MusicApiAlbum music;
            if (!memoryCache.TryGetValue(id, out music))
            {
                var result = await httpClient.GetStringAsync($"{musicApiOptions.BaseUrl}album/{id}");
                music = JsonConvert.DeserializeObject<MusicApiAlbum>(result);

                var cacheTime = new MemoryCacheEntryOptions();
                cacheTime.SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(id, music, cacheTime);
            }
            return music;
        }
    }
}
