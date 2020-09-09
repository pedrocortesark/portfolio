using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using P.DAL.EFCore.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Start.DbContextFactory
{
    public class AcademyDbContextFactory
    {
        public AcademyDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("AcademyDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();
            optionsBuilder.UseSqlServer(dbConnection, x => x.MigrationsAssembly("Web.Start"));

            return new AcademyDbContext(optionsBuilder.Options);
        }
    }
}
