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
    
    public class PlayerInput : MonoBehaviour, GameplayActionMap.IPlayerAttackActions, GameplayActionMap.IPlayerMovementActions
    {
        [SerializeField]
        private GameplayActionMap gameplayActionMap;
        
        private InputDevice playerDevice;
        
        public Vector2 MovementVector { get; private set; } = Vector2.zero;
        public Action<Vector2> OnMovePerformed;
        
        [SerializeField]
        private InputActionReference moveActionReference;

        public void Setup(InputDevice playerDevice)
        {   
            this.playerDevice = playerDevice;
            Debug.Log($"Player has joined the game! His device is {playerDevice.name}");
            OnMovePerformed = delegate(Vector2 vector2) {  };
            gameplayActionMap = new GameplayActionMap();
            gameplayActionMap.PlayerMovement.SetCallbacks(this);
            gameplayActionMap.Enable();
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
                OnMovePerformed?.Invoke(MovementVector);
            }
        }

    }
}