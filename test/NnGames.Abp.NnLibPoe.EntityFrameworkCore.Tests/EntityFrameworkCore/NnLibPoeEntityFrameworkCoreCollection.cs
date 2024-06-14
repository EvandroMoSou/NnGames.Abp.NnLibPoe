using Xunit;

namespace NnGames.Abp.NnLibPoe.EntityFrameworkCore;

[CollectionDefinition(NnLibPoeTestConsts.CollectionDefinitionName)]
public class NnLibPoeEntityFrameworkCoreCollection : ICollectionFixture<NnLibPoeEntityFrameworkCoreFixture>
{

}
