using Volo.Abp.Modularity;

namespace NnGames.Abp.NnLibPoe;

[DependsOn(
    typeof(NnLibPoeApplicationModule),
    typeof(NnLibPoeDomainTestModule)
)]
public class NnLibPoeApplicationTestModule : AbpModule
{

}
