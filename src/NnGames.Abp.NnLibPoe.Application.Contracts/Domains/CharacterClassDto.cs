using Volo.Abp.Application.Dtos;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public class CharacterClassDto : EntityDto<int>
    {
        public string? Name { get; set; }
    }
}
