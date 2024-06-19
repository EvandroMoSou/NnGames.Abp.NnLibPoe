using Necnat.Abp.NnLibCommon.Entities;
using NnGames.Abp.NnLibPoe.Models;
using Volo.Abp.Domain.Entities;

namespace NnGames.Abp.NnLibPoe.Domains.Gems
{
    public class SkillGem : Entity<int>, IGetSetEntity<int>
    {
        public new int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public Cost Cost { get; set; } = null!;
        public float? CastTimeSecond { get; set; }
        public float? CooldownSecond { get; set; }
        public float? CriticalStrikeChance { get; set; }
        public Requirement Requirement { get; set; } = null!;
        public int AttackSpeedOfBase { get; set; }
        public int AttackDamage { get; set; }
    }
}
