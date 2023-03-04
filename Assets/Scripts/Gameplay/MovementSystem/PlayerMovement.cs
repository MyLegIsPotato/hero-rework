using System;
using Project.Core.InputSystem;
using UnityEngine;

namespace Project.Gameplay.MovementSystem
{
    public class PlayerMovement : MovementSystem
    {
        [SerializeField, Range(0,0.5f)]
        private float inputDeadzone = 0.1f;
        [SerializeField, Range(5,60f)]
        private float rotateDeadzoneAngle = 30f;
        
        public InputVisualizer inputVisualizer;
        private MyPlayerInput myPlayerInput;

        private float angle;
        private float length;

        private float smoothVelocity = 0;
        private float smoothTime = 0.3f;
        
        public void Setup(MyPlayerInput myPlayerInput)
        {
            this.myPlayerInput = myPlayerInput;
            inputVisualizer.Setup(this.myPlayerInput);
        }

        private void Update()
        {
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            angle = Vector3.SignedAngle(transform.forward,
                inputVisualizer.visualizerIndicator.position - transform.position, Vector3.up);
            
            if (myPlayerInput.MovementVector.magnitude > inputDeadzone)
            {
                if (Mathf.Abs(angle) > rotateDeadzoneAngle)
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        Quaternion.LookRotation(inputVisualizer.visualizerIndicator.position - transform.position),
                        RotationSpeed * Time.deltaTime);
            }
        }
    }
}