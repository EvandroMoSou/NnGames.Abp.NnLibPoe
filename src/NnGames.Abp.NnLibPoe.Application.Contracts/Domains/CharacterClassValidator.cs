using Microsoft.Extensions.Localization;
using Necnat.Abp.NnLibCommon.Extensions;
using Necnat.Abp.NnLibCommon.Validators;
using System.Collections.Generic;

namespace NnGames.Abp.NnLibPoe.Domains
{
    public static class CharacterClassValidator
    {
        public static List<string>? Validate(CharacterClassDto dto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateName(dto.Name, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateName(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Format(stringLocalizer[ValidationMessages.Required], CharacterClassConsts.NameDisplay);

            if (value.Length < CharacterClassConsts.MinNameLength || value.Length > CharacterClassConsts.MaxNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MinMaxLength], CharacterClassConsts.NameDisplay, CharacterClassConsts.MinNameLength, CharacterClassConsts.MaxNameLength);

            return null;
        }

        #region ResultRequestDto

        public static List<string>? Validate(CharacterClassResultRequestDto resultRequestDto, IStringLocalizer stringLocalizer)
        {
            var lError = new List<string>();

            lError.AddIfNotIsNullOrWhiteSpace(ValidateNameContains(resultRequestDto.NameContains, stringLocalizer));

            if (lError.Count > 0)
                return lError;

            return null;
        }

        public static string? ValidateNameContains(string? value, IStringLocalizer stringLocalizer)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            if (value.Length < CharacterClassConsts.MinNameLength || value.Length > CharacterClassConsts.MaxNameLength)
                return string.Format(stringLocalizer[ValidationMessages.MinMaxLength], CharacterClassConsts.NameDisplay, CharacterClassConsts.MinNameLength, CharacterClassConsts.MaxNameLength);

            return null;
        }

        #endregion
    }
}
