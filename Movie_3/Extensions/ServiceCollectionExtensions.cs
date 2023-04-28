﻿using Microsoft.Extensions.DependencyInjection;
using Movie_3.Options;
using Movie_3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_3.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMovieApi(this IServiceCollection services, Action<MovieApiOptions> option)
        {
            services.AddScoped<IMovieApiService, MovieApiService>();
            services.Configure(option);
            return services;
        }
    }
}
