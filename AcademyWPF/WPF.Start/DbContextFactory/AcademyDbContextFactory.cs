using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using P.DAL.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace WPF.Start.DbContextFactory
{
    class AcademyDbContextFactory : IDesignTimeDbContextFactory<AcademyDbContext>
    {
        public AcademyDbContext CreateDbContext(string[] args)
        {
            //var stringPath = @"Y:\Dropbox\Disco_duro\_PROYECTOS_PERSONALES\_PROY_2020\00_DEV\Databases\";
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("AcademyDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();
            optionsBuilder.UseSqlite(dbConnection, x => x.MigrationsAssembly("WPF.Start"));

            return new AcademyDbContext(optionsBuilder.Options);
        }
    }
}
