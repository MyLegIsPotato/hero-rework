using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Gameplay.AnimationSystem
{
    public class PlayerAnimation : MonoBehaviour
    {
        private const string PLAYER_FORWARD_VELOCITY = "ForwardVelocity";
        private const string PLAYER_TURN_AMOUNT = "TurnAmount";

        [SerializeField] [Range(0.1f, 1.5f)]
        public float smoothTime = 0.6f;
        [SerializeField]
        private Animator playerAnimator;
        
        private Vector3 relativeMovementVector;
        private Vector3 relativeMovementVelocity;

        public void MoveTowards(Vector3 targetPosition, float speed = 1f)
        {
            var relativeTargetPosition = transform.InverseTransformPoint(targetPosition);
            relativeMovementVector = Vector3.SmoothDamp(
                relativeMovementVector,
                relativeTargetPosition,
                ref relativeMovementVelocity,
                smoothTime
            );

            if(playerAnimator == null) return;
            playerAnimator.speed = speed;
            playerAnimator.SetFloat(PLAYER_FORWARD_VELOCITY, relativeMovementVector.z);
            playerAnimator.SetFloat(PLAYER_TURN_AMOUNT, relativeMovementVector.x);
        }
    }
}