using System;
using System.Collections;
using System.Collections.Generic;
using Project.Core;
using UnityEngine;

namespace Project.Gameplay
{
    public class PlayerMovement : MonoBehaviour, IMovable
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        [field: SerializeField]
        public float DashSpeed { get; private set; }

        [field: SerializeField]
        public float RotationSpeed { get; private set; }

        public void Awake()
        {

        }

        public void Update()
        {

        }

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