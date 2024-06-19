using Necnat.Abp.NnLibCommon.Entities;
using Volo.Abp.Domain.Entities;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public class CharacterClass : Entity<int>, IGetSetEntity<int>
    {
        public new int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
