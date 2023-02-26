using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMovable
{
    public float Speed { get; }
    public float DashSpeed { get; }
    public float RotationSpeed { get; }
    
    public void Move(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Rotate(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }
}
