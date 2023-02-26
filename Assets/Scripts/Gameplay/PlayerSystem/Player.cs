using Project.Common.Factory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Gameplay.PlayerSystem
{
    public class Player : MonoBehaviour, ISpawnable<Player>
    {
        [SerializeField]
        private Project.Core.Input.PlayerInput playerInput;

        [SerializeField]
        private PlayerMovement playerMovement;

        public void Setup(InputDevice device)
        {
            playerInput.Setup(device);
            playerMovement.Setup(playerInput);
        }
        
        public Player Spawn(Transform spawnPoint)
        {
            Player newPlayer = Instantiate(this.gameObject).GetComponent<Player>();
            transform.position = spawnPoint.position;
            return newPlayer;
        }

        public void Despawn()
        {
            //TODO: Add death animation and sound - can be changed to some kind of pool system.
            Destroy(this.gameObject);
        }
    }
 
}
