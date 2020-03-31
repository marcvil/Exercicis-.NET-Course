using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using A4_DAL;
using System.IO;




namespace A4WPFApp.DbContextFactory
{
    public class AcademyDbContextFactory : IDesignTimeDbContextFactory<AcademyDbContext>
    {
        public AcademyDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true);


            var configuration = builder.Build();
            var dbConnection = configuration.GetConnectionString("AcademyDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AcademyDbContext>();
            optionsBuilder.UseSqlite(dbConnection, x => x.MigrationsAssembly("A4WPFApp"));

            return new AcademyDbContext(optionsBuilder.Options);
        }
    }
}
