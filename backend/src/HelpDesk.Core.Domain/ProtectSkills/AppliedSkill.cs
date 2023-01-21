namespace HelpDesk.Core.Domain.ProtectSkills
{
    public class AppliedSkill
    {
        public string SkillName { get; set; }

        public AppliedSkill(string skillName)
        {
            SkillName = skillName;
        }
    }

}
