using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movie_2.Extensions;
using Movie_2.Options;
using Movie_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Console.WriteLine(configuration.GetValue<string>("Title"));
            Console.WriteLine(configuration.GetSection("MovieApi").GetValue<string>("ApiKey"));
            Console.WriteLine(configuration.GetSection("MovieApi").GetValue<string>("BaseUrl"));
            Console.WriteLine(configuration[("MovieApi:ApiKey")]);
            Console.WriteLine(configuration[("MovieApi:BaseUrl")]);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddScoped<IMovieApiService ,MovieApiService>();
            //services.AddSingleton<IMovieApiService ,MovieApiService>();
            //services.AddTransient<IMovieApiService ,MovieApiService>();
            services.AddHttpClient();
            services.AddMovieApi(options =>
            {
                options.ApiKey = Configuration[("MovieApi:ApiKey")];
                options.BaseUrl = Configuration[("MovieApi:BaseUrl")];
            });
            //services.Configure<MovieApiOptions>(options =>
            //{
            //    options.ApiKey = Configuration[("MovieApi:ApiKey")];
            //    options.BaseUrl = Configuration[("MovieApi:BaseUrl")];
            //});
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}