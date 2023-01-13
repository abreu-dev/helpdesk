using HelpDesk.Core.Domain.Exceptions;

namespace HelpDesk.Core.Domain.ProtectSkills.Skills
{
    public static partial class ProtectSkillExtensions
    {
        public static IProtectSkill<string> NullOrEmpty(this IProtectSkill<string> defenderSkill)
        {
            if (string.IsNullOrEmpty(defenderSkill.PropertyValue))
            {
                throw new PropertyNullOrEmptyException(defenderSkill.PropertyName);
            }

            return defenderSkill;
        }

        public static IProtectSkill<Guid> NullOrEmpty(this IProtectSkill<Guid> defenderSkill)
        {
            if (defenderSkill.PropertyValue.Equals(Guid.Empty))
            {
                throw new PropertyNullOrEmptyException(defenderSkill.PropertyName);
            }

            return defenderSkill;
        }
    }
}
