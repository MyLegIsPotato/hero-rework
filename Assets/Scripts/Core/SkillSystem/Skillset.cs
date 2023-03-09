using System;
using System.Collections.Generic;
using Project.Core.InputSystem;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public class Skillset : MonoBehaviour
    {
        public const int MAX_SKILL_SLOTS = 4;
        
        private List<Skill> skills = new List<Skill>(MAX_SKILL_SLOTS);
        private MyPlayerInput playerInput;
        public List<Skill> Skills => skills;
        public SkillDisplay SkillDisplay { get; private set; }

        //For active skillset
        public void Setup(SkillDisplay skillDisplay, MyPlayerInput playerInput)
        {
            this.SkillDisplay = skillDisplay;
            this.playerInput = playerInput;
            this.playerInput.OnSkillSlotActivated += OnSkillSlotActivated;
        }
        
        //For passive skillset
        public void Setup(SkillDisplay skillDisplay)
        {
            this.SkillDisplay = skillDisplay;
        }

        private void OnSkillSlotActivated(int skillIndex)
        {
            if (skillIndex >= skills.Count)
                return;
            
            skills[skillIndex].UseSkill();
        }

        public void AssignSkills(List<Skill> startingSkills)
        {
            if (startingSkills.Count > MAX_SKILL_SLOTS)
            {
                Debug.LogError("Cannot assign more skills than there are slots");
                return;
            }

            for (int i = 0; i < startingSkills.Count; i++)
            {
                if (i >= skills.Count || skills[i] == null)
                {
                    skills.Insert(i, Instantiate(startingSkills[i]));
                    if(skills[i] == null)
                        continue;
                }
                else
                {
                    skills[i] = startingSkills[i];
                }

                skills[i].AssignedSlot = (SkillSlot)i;
                skills[i].SkillIndex = i;
                skills[i].OnRechargeUpdated += SkillDisplay.UpdateFillImage;
                skills[i].ActivateSkill();
                SkillDisplay.SetSkillAppearence(i, Skills[i]);
                SkillDisplay.UpdateFillImage(i, 0f);
            }

            // De-activate any unused slots
            for (int i = startingSkills.Count; i < skills.Count; i++)
            {
                skills[i].DeactivateSkill();
            }
        }
    }
}