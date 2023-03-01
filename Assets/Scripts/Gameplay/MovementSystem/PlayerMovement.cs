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
        public float turnAmount;

        private float angle;
        private float length;
        private Vector3 pointA;
        private Vector3 pointB;
        
        private float smoothVelocity = 0;
        private float smoothTime = 0.3f;
        
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

            pointA = inputVisualizer.visualizerIndicator.transform.position;
            pointB = ((Vector3)transform.position + ((Vector3)transform.forward * myPlayerInput.MovementVector.magnitude));
            length = (pointA - pointB).magnitude;
            angle = Vector3.SignedAngle(transform.forward, inputVisualizer.visualizerIndicator.position - transform.position, Vector3.up);
            Debug.Log(angle);
            
            if (myPlayerInput.MovementVector.magnitude > inputDeadzone)
            {
                if (Mathf.Abs(angle) > rotateDeadzoneAngle)
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,
                        Quaternion.LookRotation(inputVisualizer.visualizerIndicator.position - transform.position),
                        RotationSpeed * Time.deltaTime);
                movementVelocity = Mathf.SmoothDamp(movementVelocity, velocityVector.magnitude, ref smoothVelocity, smoothTime);
                
                if (angle > 5 || angle < -5)
                {
                    turnAmount = Mathf.SmoothDamp(turnAmount * Math.Sign(angle), Mathf.InverseLerp(0, rotateDeadzoneAngle, angle) * Math.Sign(angle), ref smoothVelocity, smoothTime) * Math.Sign(angle);
                    //turnAmount = Mathf.InverseLerp(-rotateDeadzoneAngle, rotateDeadzoneAngle, angle);
                }
                else
                {
                    turnAmount = Mathf.SmoothDamp(turnAmount, 0, ref smoothVelocity, smoothTime);
                }
            }
            else
            {
                movementVelocity = 0;
                //movementVelocity = Mathf.SmoothDamp(movementVelocity, 0, ref smoothVelocity, smoothTime/2);;
                turnAmount = Mathf.SmoothDamp(turnAmount, 0, ref smoothVelocity, smoothTime);
            }

        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            //Line beteen Player Front and inputVisualizer.indicator
            Gizmos.DrawLine(pointA, pointB);
        }
    }
}