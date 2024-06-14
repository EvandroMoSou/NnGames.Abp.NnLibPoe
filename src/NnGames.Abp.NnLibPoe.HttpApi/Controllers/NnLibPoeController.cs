using NnGames.Abp.NnLibPoe.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NnGames.Abp.NnLibPoe.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class NnLibPoeController : AbpControllerBase
{
    protected NnLibPoeController()
    {
        LocalizationResource = typeof(NnLibPoeResource);
    }
}
