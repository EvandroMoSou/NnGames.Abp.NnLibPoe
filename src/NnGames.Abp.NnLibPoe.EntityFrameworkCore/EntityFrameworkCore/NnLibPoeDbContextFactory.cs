using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NnGames.Abp.NnLibPoe.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NnLibPoeDbContextFactory : IDesignTimeDbContextFactory<NnLibPoeDbContext>
{
    public NnLibPoeDbContext CreateDbContext(string[] args)
    {
        NnLibPoeEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<NnLibPoeDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));

        return new NnLibPoeDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NnGames.Abp.NnLibPoe.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
