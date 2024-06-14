using NnGames.Abp.NnLibPoe.Samples;
using Xunit;

namespace NnGames.Abp.NnLibPoe.EntityFrameworkCore.Domains;

[Collection(NnLibPoeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<NnLibPoeEntityFrameworkCoreTestModule>
{

}
