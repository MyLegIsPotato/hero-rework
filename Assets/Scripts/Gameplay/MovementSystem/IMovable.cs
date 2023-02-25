using UnityEngine;

public interface IMovable
{
    float Speed { get; }
    float DashSpeed { get; }
    float RotationSpeed { get; }
    
    void Move(Vector2 direction);
    void Rotate(Vector2 direction);
    void Stop();
}
