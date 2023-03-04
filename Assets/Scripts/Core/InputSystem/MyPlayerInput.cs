using System;
using Project.Common.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Core.InputSystem
{
    public class MyPlayerInput : MonoBehaviour, GameplayActionMap.IPlayerMovementActions
    {
        [SerializeField]
        private InputActionReference moveActionReference;

        [SerializeField]
        private InputActionReference attackActionReference;

        /// <summary>
        ///     Event raised when movement input is performed.
        /// </summary>
        public Action<Vector2> OnMovementPerformed;

        private InputDevice playerDevice;
        private PlayerInput playerInput;

        public Vector2 MovementVector { get; private set; } = Vector2.zero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementVector = context.ReadValue<Vector2>();
            OnMovementPerformed?.Invoke(MovementVector);
        }

        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            playerDevice = playerInput.devices[0];
            InitializeActionMap(playerInput);
            Debug.Log($"Player has joined the game! His device is {playerDevice.name}");
        }

        private void InitializeActionMap(PlayerInput playerInput)
        {
            var map = playerInput.currentActionMap;
            map.SubscribeToAction(moveActionReference, InputActionPhase.Performed, OnMovement);
            map.SubscribeToAction(moveActionReference, InputActionPhase.Canceled, OnMovement);
            map.Enable();
        }

        public void OnActivateSkill(InputAction.CallbackContext context)
        {
        }
    }
}