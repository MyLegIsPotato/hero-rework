using System.Collections.Generic;
using Project.Core.SkillSystem;
using Project.Gameplay.PlayerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Gameplay.SkillSystem
{
    public class SkillsetController : MonoBehaviour
    {
        [SerializeField]
        private SkillDisplay passiveSkillDisplayPrefab;
        [SerializeField]
        private SkillDisplay activeSkillDisplayPrefab;

        [SerializeField]
        private List<Skill> startingPassiveSkills;

        [SerializeField]
        private List<Skill> startingActiveSkills;
        
        public Skillset passiveSkillset;
        public Skillset activeSkillset;

        private SkillDisplay passiveSkillDisplay;
        private SkillDisplay activeSkillDisplay;

        public void Setup(Player player, LayoutGroup passiveSkillSetTarget, LayoutGroup activeSkillSetTarget)
        {
            passiveSkillset = player.PassiveSkillset;
            activeSkillset = player.ActiveSkillset;

            passiveSkillDisplay = Instantiate(passiveSkillDisplayPrefab, passiveSkillSetTarget.transform);
            passiveSkillDisplay.Setup(passiveSkillset);
 
            activeSkillDisplay = Instantiate(activeSkillDisplayPrefab, activeSkillSetTarget.transform);
            activeSkillDisplay.Setup(activeSkillset);
            
            AssignStartingSkills();
        }
        
        public void AssignStartingSkills()
        {
            passiveSkillset.AssignSkills(startingPassiveSkills);
            activeSkillset.AssignSkills(startingActiveSkills);
        }
    }
}
