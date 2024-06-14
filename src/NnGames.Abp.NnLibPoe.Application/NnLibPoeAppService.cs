using System;
using System.Collections.Generic;
using System.Text;
using NnGames.Abp.NnLibPoe.Localization;
using Volo.Abp.Application.Services;

namespace NnGames.Abp.NnLibPoe;

/* Inherit your application services from this class.
 */
public abstract class NnLibPoeAppService : ApplicationService
{
    protected NnLibPoeAppService()
    {
        LocalizationResource = typeof(NnLibPoeResource);
    }
}
