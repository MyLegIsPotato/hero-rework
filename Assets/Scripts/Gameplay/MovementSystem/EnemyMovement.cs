using System;
using UnityEngine;

namespace Project.Gameplay.MovementSystem
{
    public class EnemyMovement : MonoBehaviour, ISimpleMovable
    {
        public float Speed { get; }
        public float DashSpeed { get; }
        public float RotationSpeed { get; }

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