using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrangeMoviesApp.Persistence;
using OrangeMoviesApp.Persistence.Persistence;
using OrangeMoviesApp.Web;
using OrangeMoviesApp.Web.Services;
using System;


namespace OrangeMoviesApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OrangeMoviesDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("Default")));

            services.AddControllersWithViews();

            services.AddScoped<IMoviesRepository, MoviesRepository>();

            services.AddSingleton<IOrangeMoviesApiService, OrangeMoviesApiService>();

            services.AddHttpClient("OrangeMoviesApi", c => c.BaseAddress = new Uri("https://api.themoviedb.org"));
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
                    name: "ordered",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{sortByRating?}/{groupByGenreId?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
