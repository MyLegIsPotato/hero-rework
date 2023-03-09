using System;
using System.Collections.Generic;
using Project.Core.InputSystem;
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
        
        private MyPlayerInput myPlayerInput;
        private Vector2 previousSkillSelection;

        public void SetupPlayer(MyPlayerInput playerInput, Skillset playerPassiveSkillset, Skillset playerActiveSkillset)
        {
            myPlayerInput = playerInput;
            passiveSkillset = playerPassiveSkillset;
            activeSkillset = playerActiveSkillset;
        }
        
        public void SetupDisplays(LayoutGroup passiveSkillSetTarget, LayoutGroup activeSkillSetTarget)
        {
            SkillDisplay passiveSkillDisplay = Instantiate(passiveSkillDisplayPrefab, passiveSkillSetTarget.transform);
            passiveSkillset.Setup(passiveSkillDisplay);

            SkillDisplay activeSkillDisplay = Instantiate(activeSkillDisplayPrefab, activeSkillSetTarget.transform);
            activeSkillset.Setup(activeSkillDisplay, myPlayerInput);
            
            passiveSkillset.AssignSkills(startingPassiveSkills);
            activeSkillset.AssignSkills(startingActiveSkills);
        }
    }
}
