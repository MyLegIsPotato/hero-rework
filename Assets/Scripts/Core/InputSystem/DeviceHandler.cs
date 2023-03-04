using System;
using System.Collections.Generic;
using Project.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Core.InputSystem
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
        }

        private void InitializeActions()
        {
            OnDeviceJoined = delegate { };
            OnDeviceDisconnected = delegate { };
        }

        private void InitializeMaps()
        {
            playerInputs = new List<PlayerInput>();
            joinedDevices = new List<InputDevice>();
            var joinActionMap = new JoiningActionMap();
            joinActionMap.JoinGame.SetCallbacks(this);
            joinActionMap.Enable();
        }

        public void OnJoinGame(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (joinedDevices.Contains(context.control.device))
                    return;

                AddNewPlayerByDevice(context.control.device);
            }
        }

        private void AddNewPlayerByDevice(InputDevice device)
        {
            playerInputManager.playerPrefab = playerInputHandlerPrefab.gameObject;
            var newPlayerInput =
                playerInputManager.JoinPlayer(playerInputs.Count, playerInputs.Count, "KBM", device);
            playerInputs.Add(newPlayerInput);
            joinedDevices.Add(device);
            OnDeviceJoined?.Invoke(newPlayerInput);
        }
    }
}