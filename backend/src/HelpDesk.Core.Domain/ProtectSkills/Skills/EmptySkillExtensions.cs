using HelpDesk.Core.Domain.Exceptions;

namespace HelpDesk.Core.Domain.ProtectSkills.Skills
{
    public static partial class ProtectSkillExtensions
    {
        public static string EmptySkillName => "Empty";

        public static IProtectSkill<Guid> Empty(this IProtectSkill<Guid> defenderSkill)
        {
            defenderSkill.AddAppliedSkill(EmptySkillName);

            if (defenderSkill.PropertyValue.Equals(Guid.Empty))
            {
                throw new PropertyNullOrEmptyException(defenderSkill.PropertyName);
            }

            return defenderSkill;
        }
    }
}
