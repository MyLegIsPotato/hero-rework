using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Project.Core
{
    public class MyInput : MonoBehaviour, GameplayActionMap.IPlayerAttackActions, GameplayActionMap.IPlayerMovementActions
    {
        private GameplayActionMap gameplayActionMap;

        public Action<Vector2> OnMovePerformed;
        
        private void Awake()
        {
            gameplayActionMap = new GameplayActionMap();
            gameplayActionMap.Enable();
        }

        public void OnActivateSkill(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
    }
}