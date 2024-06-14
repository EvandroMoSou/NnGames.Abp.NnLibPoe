using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NnGames.Abp.NnLibPoe.Data;

/* This is used if database provider does't define
 * INnLibPoeDbSchemaMigrator implementation.
 */
public class NullNnLibPoeDbSchemaMigrator : INnLibPoeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
