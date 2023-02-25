using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class MovementSystem : MonoBehaviour
{
    private IMovable movable;
    
    protected void Setup(IMovable movable)
    {
        this.movable = movable;
    }
}
