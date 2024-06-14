using NnGames.Abp.NnLibPoe.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace NnGames.Abp.NnLibPoe.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NnLibPoeEntityFrameworkCoreModule),
    typeof(NnLibPoeApplicationContractsModule)
    )]
public class NnLibPoeDbMigratorModule : AbpModule
{
}
