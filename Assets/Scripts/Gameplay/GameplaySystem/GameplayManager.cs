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
        
        private Dictionary<PlayerInput, Player> players;
        private PlayerFactory playerFactory;

        private void Start()
        {
            Debug.Log("Gameplay starting...");
            
            InitializePlayerSystem();
            InitializeInputHandlers();
        }


        private void InitializePlayerSystem()
        {
            players = new Dictionary<PlayerInput, Player>();
            playerFactory = new PlayerFactory();
            playerFactory.Initialize(defaultSpawnPoint);
        }

        private void InitializeInputHandlers()
        {
            DeviceHandler.Instance.Initialize();
            DeviceHandler.Instance.OnDeviceJoined += DeviceHandler_OnDeviceJoined;
        }

        private void DeviceHandler_OnDeviceJoined(PlayerInput playerInput)
        {
            Player newPlayer = playerFactory.Spawn(playerPrefab);
            players.Add(playerInput, newPlayer);
            newPlayer.Setup(playerInput);
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            Debug.Log("Game paused!");
        }
    }
}