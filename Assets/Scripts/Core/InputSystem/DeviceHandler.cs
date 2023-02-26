using System.Collections.Generic;
using UnityEngine;
using System;
using Project.Common.Patterns;
using UnityEngine.InputSystem;

namespace Project.Core.Input
{
    public class DeviceHandler : Singleton<DeviceHandler>, GameplayActionMap.IDeviceHandlerActions
    {
        private List<InputDevice> joinedDevices;

        public Action<InputDevice> OnDeviceJoined;
        public Action<InputDevice> OnDeviceDisconnected;

        public void Initialize()
        {
            InitializeMaps();
            InitializeActions();
            
            Debug.Log("Awaiting Input...");
        }

        private void InitializeActions()
        {
            OnDeviceJoined = delegate(InputDevice device) { };
            OnDeviceDisconnected = delegate(InputDevice device) { };
        }

        private void InitializeMaps()
        {
            joinedDevices = new List<InputDevice>();
            GameplayActionMap gameplayActionMap = new GameplayActionMap();
            gameplayActionMap.DeviceHandler.SetCallbacks(this);
            gameplayActionMap.Enable();
        }

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {
            if(!joinedDevices.Contains(device))
                return;

            if (change == InputDeviceChange.Removed)
            {
                OnDeviceDisconnected?.Invoke(device);
            }
        }

        public void OnJoinGame(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                InputDevice device = context.control.device;
                if (joinedDevices.Contains(device))
                    return;
                
                joinedDevices.Add(device);
                OnDeviceJoined.Invoke(device);
            }
        }
    }
}
