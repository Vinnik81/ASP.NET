using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Services
{
   public interface IMusicApiService
    {
        Task<MusicApiResponse> SearchByNameAsync(string name, int page);
        Task<MusicApiAlbum> SearchByTrackAsync(int id);
    }
}
