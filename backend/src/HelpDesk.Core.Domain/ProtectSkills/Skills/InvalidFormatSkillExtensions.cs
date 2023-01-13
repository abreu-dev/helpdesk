﻿using HelpDesk.Core.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace HelpDesk.Core.Domain.ProtectSkills.Skills
{
    public static partial class ProtectSkillExtensions
    {
        public static IProtectSkill<string> InvalidFormat(this IProtectSkill<string> defenderSkill,
                                                          string pattern)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(defenderSkill.PropertyValue))
                throw new InvalidPropertyFormatException(defenderSkill.PropertyName, defenderSkill.PropertyValue);

            return defenderSkill;
        }
    }
}
