using Project.Common.Factory;
using Project.Gameplay.AnimationSystem;
using Project.Gameplay.MovementSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Project.Gameplay.PlayerSystem
{
    public class Player : MonoBehaviour, ISpawnable<Player>
    {
        [SerializeField]
        private Project.Core.InputSystem.MyPlayerInput myPlayerInput;

        [SerializeField]
        private PlayerMovement playerMovement;

        [SerializeField]
        private PlayerAnimation playerAnimation;

        /// <summary>
        /// Sets up the player with the given input.
        /// </summary>
        public void Setup(PlayerInput playerInput)
        {
            myPlayerInput.Setup(playerInput);
            playerMovement.Setup(myPlayerInput);
            playerAnimation.Setup(myPlayerInput, playerMovement);
        }
    
        /// <summary>
        /// Instantiates a new player at the given spawn point.
        /// </summary>
        public Player Spawn(Transform spawnPoint)
        {
            var newPlayer = Instantiate(gameObject).GetComponent<Player>();
            transform.position = spawnPoint.position;
            return newPlayer;
        }

        /// <summary>
        /// Destroys the player game object and triggers a death animation and sound (TODO).
        /// </summary>
        public void Despawn()
        {
            //TODO: Add death animation and sound - can be changed to some kind of pool system.
            Destroy(gameObject);
        }
    }
}
