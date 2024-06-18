using Necnat.Abp.NnLibCommon.Dtos;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public class CharacterClassResultRequestDto : OptionalPagedAndSortedResultRequestDto
    {
        public string NameContains { get; set; } = string.Empty;
    }
}
