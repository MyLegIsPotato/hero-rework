using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Project.Common.Extensions;

namespace Project.Core.Input
{
    public class MyPlayerInput : MonoBehaviour, GameplayActionMap.IPlayerMovementActions
    {
        private PlayerInput playerInput;
        private InputDevice playerDevice;
        
        public Vector2 MovementVector { get; private set; } = Vector2.zero;
        public bool IsAttackHeld { get; private set; }
         
        public Action<Vector2> OnMovementPerformed;
        
        [SerializeField]
        private InputActionReference moveActionReference;
        [SerializeField]
        private InputActionReference attackActionReference;
        
        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            this.playerDevice = playerInput.devices[0];
            InitializeActionMap(playerInput);
            Debug.Log($"Player has joined the game! His device is {playerDevice.name}");
        }

        private void InitializeActionMap(PlayerInput playerInput)
        {
            InputActionMap map = playerInput.currentActionMap;
            map.SubscribeToAction(moveActionReference, InputActionPhase.Performed, OnMovement);
            map.SubscribeToAction(moveActionReference, InputActionPhase.Canceled, OnMovement);
            map.Enable();
        }
        
        public void OnActivateSkill(InputAction.CallbackContext context)
        {
            
        }
        
        public void OnMovement(InputAction.CallbackContext context)
        {
            Debug.Log($"Input on {context.control.device.name} is {context.ReadValue<Vector2>()}, phase: {context.phase}");
            MovementVector = context.ReadValue<Vector2>();
            OnMovementPerformed?.Invoke(MovementVector);
        }

    }
}