using Project.Core.SkillSystem;
using UnityEngine;

namespace Project.Gameplay.Skills
{
    public class SkillSpirits : Skill
    {
        public override void UseSkill()
        {
            base.UseSkill();
            Debug.Log("Spirit Shot!");
        }
    }
}
