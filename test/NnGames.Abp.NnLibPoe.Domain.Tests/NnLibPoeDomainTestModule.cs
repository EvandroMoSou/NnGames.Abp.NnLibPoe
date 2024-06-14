using Volo.Abp.Modularity;

namespace NnGames.Abp.NnLibPoe;

[DependsOn(
    typeof(NnLibPoeDomainModule),
    typeof(NnLibPoeTestBaseModule)
)]
public class NnLibPoeDomainTestModule : AbpModule
{

}
