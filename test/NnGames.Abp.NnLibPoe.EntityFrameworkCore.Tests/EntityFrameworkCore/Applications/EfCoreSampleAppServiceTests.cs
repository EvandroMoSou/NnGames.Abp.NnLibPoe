using NnGames.Abp.NnLibPoe.Samples;
using Xunit;

namespace NnGames.Abp.NnLibPoe.EntityFrameworkCore.Applications;

[Collection(NnLibPoeTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<NnLibPoeEntityFrameworkCoreTestModule>
{

}
