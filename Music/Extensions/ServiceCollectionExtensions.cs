using Microsoft.Extensions.DependencyInjection;
using Music.Options;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMusicApi(this IServiceCollection services, Action<MusicApiOptions> option)
        {
            services.AddScoped<IMusicApiService, MusicApiService>();
            services.Configure(option);
            return services;
        }
    }
}
