using Volo.Abp.Modularity;

namespace NnGames.Abp.NnLibPoe;

public abstract class NnLibPoeApplicationTestBase<TStartupModule> : NnLibPoeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
