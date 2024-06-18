using Necnat.Abp.NnLibCommon.Entities;
using System.Text.Json.Serialization;
using Volo.Abp.Domain.Entities;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public class CharacterClass : Entity<int>, IGetSetEntity<int>
    {
        [JsonPropertyName("id")]
        public new int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
