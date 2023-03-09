using System.Collections.Generic;
using Project.Common;
using Project.Core.InputSystem;
using Project.Core.SkillSystem;
using Project.Gameplay.PlayerSystem;
using Project.Gameplay.SkillSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Project.Gameplay.GameplaySystem
{
    public class GameplayManager : Singleton<GameplayManager>
    {
        [SerializeField]
        private Player playerPrefab;

        [SerializeField]
        private Transform defaultSpawnPoint;
        
        
        [Space(10f), SerializeField]
        private SkillDisplay skillDisplayPrefab;
        [SerializeField]
        private LayoutGroup passiveSkillSetTarget;
        [SerializeField]
        private LayoutGroup activeSkillSetTarget;
        
        private PlayerFactory playerFactory;

        private readonly Dictionary<PlayerInput, Player> players = new();

        private void Start()
        {
            Debug.Log("Gameplay starting...");
            InitializePlayerSystem();
            InitializeInputHandlers();
        }

        private void InitializePlayerSystem()
        {
            playerFactory = new PlayerFactory();
            playerFactory.Initialize(defaultSpawnPoint);
        }

        private void InitializeInputHandlers()
        {
            DeviceHandler.Instance.Initialize();
            DeviceHandler.Instance.OnDeviceJoined += OnNewPlayerDeviceJoined;
        }

        private void OnNewPlayerDeviceJoined(PlayerInput playerInput)
        {
            var newPlayer = AddNewPlayer(playerInput);
            ReparentInputHandler(playerInput, newPlayer);
        }

        private Player AddNewPlayer(PlayerInput playerInput)
        {
            var newPlayer = playerFactory.Spawn(playerPrefab);
            players.Add(playerInput, newPlayer);
            newPlayer.Setup(playerInput, passiveSkillSetTarget, activeSkillSetTarget);
            return newPlayer;
        }

        private void ReparentInputHandler(PlayerInput playerInput, Player player)
        {
            playerInput.transform.SetParent(player.transform);
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            Debug.Log("Game paused!");
        }
    }
}