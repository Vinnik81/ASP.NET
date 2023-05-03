using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Services
{
    public class RecentMusicStorage : IRecentMusicStorage
    {
        public ConcurrentQueue<Datum> Musics { get; set; } = new ConcurrentQueue<Datum>();

        public void Add(Datum music)
        {
            if (!Musics.Contains(music))
            {
                Musics.Enqueue(music);
            }

            if (Musics.Count > 4)
            {
                Musics.TryDequeue(out Datum trash);
            }
        }

        public IEnumerable<Datum> GetMusics()
        {
            return Musics.Take(4);
        }
    }
}
