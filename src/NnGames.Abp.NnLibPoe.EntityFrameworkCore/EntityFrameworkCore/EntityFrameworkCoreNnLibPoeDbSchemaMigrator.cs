using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NnGames.Abp.NnLibPoe.Data;
using Volo.Abp.DependencyInjection;

namespace NnGames.Abp.NnLibPoe.EntityFrameworkCore;

public class EntityFrameworkCoreNnLibPoeDbSchemaMigrator
    : INnLibPoeDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNnLibPoeDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the NnLibPoeDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NnLibPoeDbContext>()
            .Database
            .MigrateAsync();
    }
}
