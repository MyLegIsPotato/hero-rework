using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Project.Core.Input
{
    public enum ActionState
    {
        Performed,
        Canceled
    }
    
    public class MyPlayerInput : MonoBehaviour
    {
        private PlayerInput playerInput;
        private InputDevice playerDevice;
        
        public Vector2 MovementVector { get; private set; } = Vector2.zero;
        
        public Action<Vector2> OnMovementPerformed;
        
        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            this.playerDevice = playerInput.devices[0];
            
            Debug.Log($"Player has joined the game! His device is {playerDevice.name}");
        }

        public void Update()
        {
           
        }
        
        public void OnActivateSkill(InputAction.CallbackContext context)
        {

        }
        
        public void OnMovement(InputAction.CallbackContext context)
        {
            Debug.Log($"Input on {context.control.device.name} is {context.ReadValue<Vector2>()}, phase: {context.phase}");
            if (playerDevice == context.control.device)
            {
                MovementVector = context.ReadValue<Vector2>();
                //OnMovePerformed?.Invoke(MovementVector);
            }
        }

    }
}