using System.Threading.Tasks;

namespace NnGames.Abp.NnLibPoe.Data;

public interface INnLibPoeDbSchemaMigrator
{
    Task MigrateAsync();
}
