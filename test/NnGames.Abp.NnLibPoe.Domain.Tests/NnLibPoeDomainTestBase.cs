using Volo.Abp.Modularity;

namespace NnGames.Abp.NnLibPoe;

/* Inherit from this class for your domain layer tests. */
public abstract class NnLibPoeDomainTestBase<TStartupModule> : NnLibPoeTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
