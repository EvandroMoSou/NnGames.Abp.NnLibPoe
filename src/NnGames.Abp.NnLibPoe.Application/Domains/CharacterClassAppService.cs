using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Localization;
using Necnat.Abp.NnLibCommon.Services;
using System.Linq;
using System.Threading.Tasks;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public class CharacterClassAppService : NecnatAppService<CharacterClass, CharacterClassDto, int, CharacterClassResultRequestDto, ICharacterClassRepository>, ICharacterClassAppService
    {
        public CharacterClassAppService(IStringLocalizer<NnLibCommonResource> necnatLocalizer,
            ICharacterClassRepository repository) : base(necnatLocalizer, repository)
        {

        }

        protected override async Task<IQueryable<CharacterClass>> CreateFilteredQueryAsync(CharacterClassResultRequestDto input)
        {
            ThrowIfIsNotNull(CharacterClassValidator.Validate(input, _necnatLocalizer));

            var q = await ReadOnlyRepository.GetQueryableAsync();

            if (!string.IsNullOrWhiteSpace(input.NameContains))
                q = q.Where(x => x.Name.Contains(input.NameContains));

            return q;
        }
    }
}
