using System;
using Project.Common.Factory;
using Project.Core.InputSystem;
using Project.Core.SkillSystem;
using Project.Gameplay.AnimationSystem;
using Project.Gameplay.MovementSystem;
using Project.Gameplay.SkillSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Project.Gameplay.PlayerSystem
{
    public class Player : MonoBehaviour, ISpawnable<Player>
    {
        [SerializeField]
        private MyPlayerInput myPlayerInput;
        [SerializeField]
        private PlayerMovement playerMovement;
        [SerializeField]
        private PlayerAnimation playerAnimation;
        [SerializeField]
        private  SkillsetController skillsetController;
        [SerializeField]
        private Skillset passiveSkillset;
        [SerializeField]
        private Skillset activeSkillset;
        
        public Skillset PassiveSkillset => passiveSkillset;
        public Skillset ActiveSkillset => activeSkillset;
        
        public Player Spawn(Transform spawnPoint)
        {
            var newPlayer = Instantiate(gameObject).GetComponent<Player>();
            transform.position = spawnPoint.position;
            return newPlayer;
        }
        
        public void Despawn()
        {
            //TODO: Add death animation and sound - can be changed to some kind of pool system.
            Destroy(gameObject);
        }

        public void Setup(PlayerInput playerInput, LayoutGroup passiveSkillsetTarget, LayoutGroup activeSkillsetTarget)
        {
            myPlayerInput.Setup(playerInput);
            playerMovement.Setup(myPlayerInput, playerAnimation);
            skillsetController.SetupPlayer(myPlayerInput, passiveSkillset, activeSkillset);
            skillsetController.SetupDisplays(passiveSkillsetTarget, activeSkillsetTarget);
        }
    }
}