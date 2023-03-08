using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public class Skillset : MonoBehaviour
    {
        public const int MAX_SKILL_SLOTS = 4;
        
        private List<Skill> skills = new List<Skill>(MAX_SKILL_SLOTS);

        public List<Skill> Skills => skills;
        public event Action<int, Skill> OnSkillSlotUpdated;

        public void UseSkill(Skill skill)
        {
            if (skill == null || !skills.Contains(skill))
            {
                return;
            }

            skill.UseSkill();
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
                    skills.Insert(i, startingSkills[i]);
                    if(skills[i] == null)
                        continue;
                }
                else
                {
                    skills[i] = startingSkills[i];
                }

                skills[i].AssignedSlot = (SkillSlot)i;
                skills[i].SkillIndex = i;
                OnSkillSlotUpdated?.Invoke(skills[i].SkillIndex, skills[i]);
            }

            // De-activate any unused slots
            for (int i = startingSkills.Count; i < skills.Count; i++)
            {
                skills[i].DeactivateSkill();
            }
        }
    }
}