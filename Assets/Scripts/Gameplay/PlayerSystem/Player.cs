using System.Collections;
using System.Collections.Generic;
using Project.Common.Factory;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Project.Core.PlayerInput;

namespace Project.Gameplay.PlayerSystem
{
    public class Player : MonoBehaviour, ISpawnable
    {
        [SerializeField]
        private PlayerInput playerInput;

        [SerializeField]
        private PlayerMovement playerMovement;

        public void Setup(InputDevice device)
        {
            playerInput.Setup(device);
        }
        
        public void Spawn(Transform spawnPoint)
        {
            Instantiate(this.gameObject, spawnPoint.position, Quaternion.identity);
        }

        public void Despawn()
        {
            //TODO: Add death animation and sound - can be changed to some kind of pool system.
            Destroy(this.gameObject);
        }
    }
 
}
