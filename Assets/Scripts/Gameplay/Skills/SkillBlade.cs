using Project.Core.SkillSystem;
using UnityEngine;

namespace Project.Gameplay.Skills
{
    public class SkillBlade : Skill
    {
        public override void UseSkill()
        {
            base.UseSkill();
            Debug.Log("Blade!");
        }
    }
}
