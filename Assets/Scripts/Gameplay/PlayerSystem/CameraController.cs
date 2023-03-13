using Cinemachine;
using Project.Gameplay.GameplaySystem;
using UnityEngine;
using Zenject;

namespace Project.Gameplay.PlayerSystem
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private CinemachineTargetGroup cameraTargetGroup;
        
        private void Start()
        {
            GameplayManager.Instance.OnPlayerJoined += OnPlayerJoined;
        }

        private void OnPlayerJoined(Player player)
        {
            cameraTargetGroup.AddMember(player.transform, 1f, 0f);
        }
    }
}
