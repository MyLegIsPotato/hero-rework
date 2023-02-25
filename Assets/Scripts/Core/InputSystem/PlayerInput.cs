using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Project.Core
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

        public Vector2 MovementVector => gameplayActionMap.PlayerMovement.Movement.ReadValue<Vector2>().normalized;
        public Action<Vector2> OnMovePerformed;

        public void Setup(InputDevice playerDevice)
        {   
            this.playerDevice = playerDevice;
            Debug.Log($"Player has joined the game! His device is {playerDevice.name}");
        }
        
        private void Awake()
        {
            // Enable the gameplay action map
            gameplayActionMap = new GameplayActionMap();
            gameplayActionMap.Enable();
        }
        
        
        public void OnActivateSkill(InputAction.CallbackContext context)
        {

        }
        
        public void OnMovement(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

    }
}