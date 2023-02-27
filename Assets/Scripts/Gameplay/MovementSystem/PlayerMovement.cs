using System;
using Project.Core.Input;
using UnityEngine;

namespace Project.Gameplay
{
    public class PlayerMovement : MovementSystem
    {
        [SerializeField, Range(0,0.5f)]
        private float inputDeadzone = 0.1f;
        [SerializeField, Range(5,60f)]
        private float rotateDeadzoneAngle = 30f;
        
        public InputVisualizer inputVisualizer;
        private MyPlayerInput myPlayerInput;

        public float movementVelocity;
        
        public void Setup(MyPlayerInput myPlayerInput)
        {
            this.myPlayerInput = myPlayerInput;
            inputVisualizer.Setup(this.myPlayerInput);
        }

        private void Update()
        {
            if (myPlayerInput == null)
                return;
           // UpdatePosition();
           UpdateRotation();
        }

        private void UpdatePosition()
        {
            this.transform.position += new Vector3(
                myPlayerInput.MovementVector.x * Speed * Time.deltaTime,
                0,
                myPlayerInput.MovementVector.y * Speed * Time.deltaTime);
        }

        private void UpdateRotation()
        {
            Vector3 velocityVector = inputVisualizer.visualizerIndicator.position - transform.position;
            movementVelocity = velocityVector.magnitude;
            
            if (myPlayerInput.MovementVector.magnitude > inputDeadzone)
            {
                //Calculate angle between Player's forward and location of inputVisualizer.indicator
                float angle = Vector3.SignedAngle(transform.forward, inputVisualizer.visualizerIndicator.position - transform.position, Vector3.up);
                Debug.Log("Angle: " + angle + "");

                
                if(Mathf.Abs(angle) > rotateDeadzoneAngle)
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(inputVisualizer.visualizerIndicator.position - transform.position), RotationSpeed * Time.deltaTime); 
                        //Quaternion.LookRotation(new Vector3(myPlayerInput.MovementVector.x, 0, myPlayerInput.MovementVector.y));
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.forward, transform.position + Vector3.forward);
            Gizmos.DrawLine(transform.forward, inputVisualizer.visualizerIndicator.position - transform.position);
        }
    }
}