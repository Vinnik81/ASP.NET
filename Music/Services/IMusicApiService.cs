using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Services
{
   public interface IMusicApiService
    {
        Task<MusicApiResponse> SearchByNameAsync(string name);
        Task<MusicApiResponse> SearchByTrackAsync(string title);
    }
}
