using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace NnGames.Abp.NnLibPoe.Blazor;

[Dependency(ReplaceServices = true)]
public class NnLibPoeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NnLibPoe";
}
