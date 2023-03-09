using Project.Core.SkillSystem;
using UnityEngine;

namespace Project.Gameplay.SkillSystem.Skills
{
    public class SkillSpin : Skill
    {
        public override void UseSkill()
        {
            if(skillTimer.TimeToFinish > 0)
                return;
            skillTimer.Reset();
            Debug.Log("Spin!");
        }
    }
}
