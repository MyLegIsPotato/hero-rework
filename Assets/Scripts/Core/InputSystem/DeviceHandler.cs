using System.Collections.Generic;
using UnityEngine;
using System;
using Project.Common.Patterns;
using UnityEngine.InputSystem;

namespace Project.Core.Input
{
    public class DeviceHandler : Singleton<DeviceHandler>, JoiningActionMap.IJoinGameActions
    {
        private List<InputDevice> joinedDevices;
        private List<PlayerInput> playerInputs;

        public Action<PlayerInput> OnDeviceJoined;
        public Action<PlayerInput> OnDeviceDisconnected;

        [SerializeField]
        private PlayerInputManager playerInputManager;

        [SerializeField]
        private PlayerInput playerInputHandlerPrefab;
        
        public void Initialize()
        {
            InitializeMaps();
            InitializeActions();

            playerInputManager.onPlayerJoined += PlayerInputManager_onPlayerJoined;
        }
        
        public void OnJoinGame(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if(joinedDevices.Contains(context.control.device))
                    return;

                playerInputManager.playerPrefab = playerInputHandlerPrefab.gameObject;
                PlayerInput newPlayerInput = playerInputManager.JoinPlayer(playerInputs.Count, playerInputs.Count, "KBM", context.control.device);
                newPlayerInput.transform.parent = transform;
                playerInputs.Add(newPlayerInput);
                joinedDevices.Add(context.control.device);
                OnDeviceJoined?.Invoke(newPlayerInput);
            }
        }
        
        private void PlayerInputManager_onPlayerJoined(UnityEngine.InputSystem.PlayerInput playerInput)
        {
            Debug.Log($"Player joined using {playerInput.name}!");
        }
        
        private void InitializeActions()
        {
            OnDeviceJoined = delegate(PlayerInput device) { };
            OnDeviceDisconnected = delegate(PlayerInput device) { };
        }

        private void InitializeMaps()
        {
            playerInputs = new List<PlayerInput>();
            joinedDevices = new List<InputDevice>();
            JoiningActionMap joinActionMap = new JoiningActionMap();
            joinActionMap.JoinGame.SetCallbacks(this);
            joinActionMap.Enable();
        }
    }
}
