using System;
using Project.Common.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Project.Core.InputSystem
{
    public class MyPlayerInput : MonoBehaviour, GameplayActionMap.IPlayerMovementActions, GameplayActionMap.IPlayerAttackActions
    {
        [SerializeField]
        private InputActionReference moveActionReference;
        [SerializeField]
        private InputActionReference activateSkillOnSelectionReference;
        [SerializeField]
        private InputActionReference selectSkillActionReference;
        [SerializeField]
        private InputActionReference activateSkillOnPressActionReference;
        
        public Action<Vector2> OnMovementPerformed;
        public Action<int> OnSkillSlotActivated;

        private InputDevice playerDevice;
        private PlayerInput playerInput;
        private Vector2 selectionVectorPosition;
        
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
            
            var attackMap = playerInput.actions.FindActionMap("PlayerAttack");
            attackMap.SubscribeToAction(activateSkillOnPressActionReference, InputActionPhase.Performed, OnActivateSkillOnPress);
            attackMap.SubscribeToAction(activateSkillOnSelectionReference, InputActionPhase.Performed, OnActivateSkillOnSelection);
            attackMap.SubscribeToAction(selectSkillActionReference, InputActionPhase.Performed, OnSelectSkill);
            attackMap.Enable();
        }

        public void OnSelectSkill(InputAction.CallbackContext context)
        {
            //TODO: Implement one day. Not now, too hard.
            //selectionVectorPosition += context.ReadValue<Vector2>().normalized;
            //Debug.Log(selectionVectorPosition.normalized);
        }

        public void OnActivateSkillOnSelection(InputAction.CallbackContext context)
        {
            //TODO: Implement one day. Not now, too hard.
            //Debug.Log("OnActivateSkillOnSelection = Activating skill after selection");
        }

        public void OnActivateSkillOnPress(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Vector2 skillSlotPosition = context.ReadValue<Vector2>();
                if (skillSlotPosition == Vector2.up)
                {
                    OnSkillSlotActivated?.Invoke(0);
                }
                else if (skillSlotPosition == Vector2.down)
                {
                    OnSkillSlotActivated?.Invoke(2);
                }
                else if (skillSlotPosition == Vector2.right)
                {
                    OnSkillSlotActivated?.Invoke(1);
                }
                else if (skillSlotPosition == Vector2.left)
                {
                    OnSkillSlotActivated?.Invoke(3);
                }
            }
        }
    }
}