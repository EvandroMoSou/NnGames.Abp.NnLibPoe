using System;
using Volo.Abp.Application.Services;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public interface IBillingClientAppService :
        ICrudAppService<
            CharacterClass,
            Guid,
            CharacterClassResultRequestDto>
    {

    }
}
