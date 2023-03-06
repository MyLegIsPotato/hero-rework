using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public class Skillset : MonoBehaviour
    {
        public SkillDisplay skillDisplay;

        private List<Skill> skills = new List<Skill>();
        public Skill NorthSkill;
        public Skill SouthSkill;
        public Skill EastSkill;
        public Skill WestSkill;
        
        public void Setup(SkillDisplay display)
        {
            skillDisplay = display;
            //Make a copy of the skills
            NorthSkill = Instantiate(NorthSkill, skillDisplay.transform);
            NorthSkill.AssignedSlot = SkillSlot.North;
            SouthSkill = Instantiate(SouthSkill, skillDisplay.transform);
            SouthSkill.AssignedSlot = SkillSlot.South;
            EastSkill = Instantiate(EastSkill, skillDisplay.transform);
            EastSkill.AssignedSlot = SkillSlot.East;
            WestSkill = Instantiate(WestSkill, skillDisplay.transform);
            WestSkill.AssignedSlot = SkillSlot.West;
            
            //Collect them in a list
            skills.Add(NorthSkill);
            skills.Add(SouthSkill);
            skills.Add(EastSkill);
            skills.Add(WestSkill);

            foreach (var skill in skills)
                skill.ActivateSkill();
            
            skillDisplay.Setup(this);
            
            foreach (var skill in skills)
                skillDisplay.SetSkillColors(skill.AssignedSlot, skill.skillSettings.SkillColor, skill.skillSettings.SkillBackground);
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
