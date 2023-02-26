using System.Collections.Generic;
using Project.Common.Patterns;
using Project.Core.Input;
using Project.Gameplay.PlayerSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Gameplay.GameplaySystem
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        [SerializeField]
        private Player playerPrefab;

        [SerializeField]
        private Transform defaultSpawnPoint;
        
        private Dictionary<InputDevice, Player> players;
        private PlayerFactory playerFactory;

        private void Start()
        {
            Debug.Log("Gameplay starting...");
            
            InitializePlayerSystem();
            InitializeInputHandlers();
        }

        private void InitializePlayerSystem()
        {
            players = new Dictionary<InputDevice, Player>();
            playerFactory = new PlayerFactory();
            playerFactory.Initialize(defaultSpawnPoint);
        }

        private void InitializeInputHandlers()
        {
            DeviceHandler.Instance.Initialize();
            DeviceHandler.Instance.OnDeviceJoined += DeviceHandler_OnDeviceJoined;
            DeviceHandler.Instance.OnDeviceDisconnected += DeviceHandler_OnDeviceDisconnected;
        }

        private void DeviceHandler_OnDeviceJoined(InputDevice device)
        {
            Debug.Log($"Player joined using {device.name}!");
            Player newPlayer = playerFactory.Spawn(playerPrefab);
            newPlayer.Setup(device);
        }

        private void DeviceHandler_OnDeviceDisconnected(InputDevice device)
        {
            players.TryGetValue(device, out Player disconnectedPlayer);
            PauseGame();
            Debug.Log($"{disconnectedPlayer} disconnected! Plug the controller back in!");
        }
        
        private void PauseGame()
        {
            Time.timeScale = 0;
            Debug.Log("Game paused!");
        }
    }
}