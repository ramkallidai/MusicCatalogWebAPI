using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Musicalog.Api.EFCore;
//using Musicalog.Api.Services;
using Musicalog.Api.EFCore.Interfaces;
using Musicalog.Api.EFCore.Repositories;

namespace Musicalog.Web.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Musicalog.Api.EFCore.MusicCatalogContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(Musicalog.Api.EFCore.MusicCatalogContext).Assembly.FullName)));
            //services.AddTransient(typeof(IAlbumService), typeof(AlbumService));
            //services.AddTransient<IAlbumService, AlbumService>();
            //services.AddScoped(typeof(IAlbumService), typeof(AlbumService));
            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            //services.AddScoped<IAlbumRepository>(provider => provider.GetService<AlbumRepository>());
            //services.AddScoped<IAlbumRepository>(provider => provider.GetService<AlbumRepository>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
