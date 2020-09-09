using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Lib.Core;
using Common.Lib.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using P.DAL.EFCore.Context;
using Web.Start.App;

namespace Web.Start
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
            services.AddControllers();

            var dbConnection = Configuration.GetConnectionString("AcademyDbConnection"); //"Data Source=ProjectDb.db";//
            services.AddDbContext<AcademyDbContext>(options => options.UseSqlServer(dbConnection, b => b.MigrationsAssembly("Web.Start")));

            var bootstrapper = new Bootstrapper();
            bootstrapper.Init();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            //Indispensable para cargar info estática
            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
