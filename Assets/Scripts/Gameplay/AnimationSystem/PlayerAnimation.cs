using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core.Input;
namespace Project.Gameplay.AnimationSystem
{
    public class PlayerAnimation : MonoBehaviour
    {
        private MyPlayerInput myPlayerInput;
        private Animator anim;
        private float smoothingFactor = 0.01f;
        private Vector2 smoothedInput = Vector2.zero; // added smoothedInput

        // Tune this value to adjust the smoothing amount
       

        public void Setup(MyPlayerInput myPlayerInput)
        {
            this.myPlayerInput = myPlayerInput;
        }

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            smoothedInput = Vector2.Lerp(smoothedInput, myPlayerInput.MovementVector, smoothingFactor); // apply smoothing to the MovementVector
            anim.SetFloat("velx", smoothedInput.x);
            anim.SetFloat("vely", smoothedInput.y);
        }
    }

}
