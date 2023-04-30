﻿using Movie_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_4.Services
{
   public interface IRecentMovieStorage
    {
        IEnumerable<Cinema> GetCinemas();
        void Add(Cinema cinema);
    }
}
