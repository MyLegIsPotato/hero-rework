using Project.Core.InputSystem;
using Project.Gameplay.MovementSystem;
using UnityEngine;

namespace Project.Gameplay.AnimationSystem
{
    public class PlayerAnimation : MonoBehaviour
    {
        private const string PLAYER_FORWARD_VELOCITY = "ForwardVelocity";
        private const string PLAYER_TURN_AMOUNT = "TurnAmount";

        public float smoothTime = 0.6f;
        private Animator anim;

        private MyPlayerInput myPlayerInput;
        private PlayerMovement playerMovement;
        private Vector3 relativeMovementVector;
        private Vector3 relativeMovementVelocity;
        private float smoothedVelocity;
        private float smoothingFactor = 1f;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            var worldPosition = playerMovement.inputVisualizer.visualizerIndicator.position;
            var relativeTargetPosition = transform.InverseTransformPoint(worldPosition);

            relativeMovementVector = Vector3.SmoothDamp(
                relativeMovementVector,
                relativeTargetPosition,
                ref relativeMovementVelocity,
                smoothTime
            );

            anim.SetFloat(PLAYER_FORWARD_VELOCITY, relativeMovementVector.z);
            anim.SetFloat(PLAYER_TURN_AMOUNT, relativeMovementVector.x);
        }

        private void OnDrawGizmos()
        {
            // Draw a sphere at the relative position
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + relativeMovementVector, 0.1f);
        }


        public void Setup(MyPlayerInput myPlayerInput, PlayerMovement playerMovement)
        {
            this.myPlayerInput = myPlayerInput;
            this.playerMovement = playerMovement;
        }
    }
}