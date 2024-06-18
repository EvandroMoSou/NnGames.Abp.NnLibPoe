using AutoMapper;
using NnGames.Abp.NnLibPoe.Domains;

namespace NnGames.Abp.NnLibPoe;

public class NnLibPoeApplicationAutoMapperProfile : Profile
{
    public NnLibPoeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CharacterClass, CharacterClassDto>();
        CreateMap<CharacterClassDto, CharacterClass>();
    }
}
