using NnGames.Abp.NnLibPoe.Repositories;
using Volo.Abp.Domain.Repositories;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public interface ICharacterClassRepository : IRepository<CharacterClass, int>, IPoeRepository
    {

    }
}
