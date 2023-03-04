using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Project.Gameplay.MovementSystem
{
    public abstract class MovementSystem : MonoBehaviour, IMovable
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float DashSpeed { get; private set; }

        [field: SerializeField]
        public float RotationSpeed { get; private set; }

        private Vector3 movementVector;

        public void Move(Vector2 direction)
        {

        }

        public void Rotate(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
