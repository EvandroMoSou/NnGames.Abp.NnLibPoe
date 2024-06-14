using NnGames.Abp.NnLibPoe.Localization;
using Volo.Abp.AspNetCore.Components;

namespace NnGames.Abp.NnLibPoe.Blazor;

public abstract class NnLibPoeComponentBase : AbpComponentBase
{
    protected NnLibPoeComponentBase()
    {
        LocalizationResource = typeof(NnLibPoeResource);
    }
}
