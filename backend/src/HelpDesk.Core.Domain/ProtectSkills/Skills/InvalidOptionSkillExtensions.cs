using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Core.Domain.Extensions;

namespace HelpDesk.Core.Domain.ProtectSkills.Skills
{
    public static partial class ProtectSkillExtensions
    {
        public static string InvalidOptionSkillName => "InvalidOption";

        public static IProtectSkill<string> InvalidOption<TEnum>(this IProtectSkill<string> defenderSkill) where TEnum : Enum
        {
            defenderSkill.AddAppliedSkill(InvalidOptionSkillName);

            var isAnEnum = EnumExtensions.IsAnEnumDisplayDescriptions<TEnum>(defenderSkill.PropertyValue);

            if (!isAnEnum)
            {
                throw new InvalidPropertyOptionException(defenderSkill.PropertyName, defenderSkill.PropertyValue);
            }

            return defenderSkill;
        }
    }
}
