using Project.Common.Factory;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Project.Gameplay.PlayerSystem
{
    public class Player : MonoBehaviour, ISpawnable<Player>
    {
        [FormerlySerializedAs("playerInput")] [SerializeField]
        private Project.Core.Input.MyPlayerInput myPlayerInput;

        [SerializeField]
        private PlayerMovement playerMovement;

        public void Setup(PlayerInput playerInput)
        {
            myPlayerInput.Setup(playerInput);
            playerMovement.Setup(myPlayerInput);
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
