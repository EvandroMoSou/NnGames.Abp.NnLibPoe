using System;
using Volo.Abp.Application.Services;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public interface ICharacterClassAppService :
        ICrudAppService<
            CharacterClassDto,
            int,
            CharacterClassResultRequestDto>
    {

    }
}
