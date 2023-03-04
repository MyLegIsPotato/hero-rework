using System;
using UnityEngine;

namespace Project.Gameplay.MovementSystem
{
    public abstract class MovementSystem : MonoBehaviour, ISimpleMovable
    {
        private Vector3 movementVector;

        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float DashSpeed { get; private set; }

        [field: SerializeField]
        public float RotationSpeed { get; private set; }

        public void Move(Vector2 direction)
        {
            throw new NotImplementedException();
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