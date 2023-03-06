using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public class Skillset : MonoBehaviour
    {
        public SkillDisplay skillDisplay;

        public Skill NorthSkill;
        public Skill SouthSkill;
        public Skill EastSkill;
        public Skill WestSkill;
        
        public void Setup(SkillDisplay display)
        {
            skillDisplay = display;
            NorthSkill = Instantiate(NorthSkill, skillDisplay.transform);
            NorthSkill.ActivateSkill();
            SouthSkill = Instantiate(SouthSkill, skillDisplay.transform);
            SouthSkill.ActivateSkill();
            EastSkill = Instantiate(EastSkill, skillDisplay.transform);
            EastSkill.ActivateSkill();
            WestSkill = Instantiate(WestSkill, skillDisplay.transform);
            WestSkill.ActivateSkill();
            
            skillDisplay.Setup(this);
        }
        
        public void Update()
        {
            Simulate();
        }
        
        //TODO: Remove this method - make the skillset use the input system
        public void Simulate()
        {
            UseSkill(SkillSlot.North);
            UseSkill(SkillSlot.South);
            UseSkill(SkillSlot.East);
            UseSkill(SkillSlot.West);
        }

        public void UseSkill(SkillSlot slot)
        {
            switch (slot)
            {
                case SkillSlot.North:
                    TryUseSkill(NorthSkill);
                    break;
                case SkillSlot.South:
                    TryUseSkill(SouthSkill);
                    break;
                case SkillSlot.East:
                    TryUseSkill(EastSkill);
                    break;
                case SkillSlot.West:
                    TryUseSkill(WestSkill);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slot), slot, null);              
            }
        }

        public void TryUseSkill(Skill skill)
        {
            if(skill == null)
                return;
            skill.UseSkill();
        }
    }
}
