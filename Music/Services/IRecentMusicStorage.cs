using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Services
{
    public interface IRecentMusicStorage
    {
        IEnumerable<Datum> GetMusics();
        void Add(Datum music);
    }
}
