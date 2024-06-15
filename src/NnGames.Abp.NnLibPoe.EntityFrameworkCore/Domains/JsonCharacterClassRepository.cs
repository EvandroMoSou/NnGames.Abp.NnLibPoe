using NnGames.Abp.NnLibPoe.Repositories;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public class JsonCharacterClassRepository : IntPoeRepository<CharacterClass>, ICharacterClassRepository
    {
        public JsonCharacterClassRepository() : base("character_class")
        {

        }
    }
}