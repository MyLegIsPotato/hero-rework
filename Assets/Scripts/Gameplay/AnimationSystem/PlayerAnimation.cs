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
             
            anim.SetFloat("velx", myPlayerInput.MovementVector.x);
            anim.SetFloat("vely", myPlayerInput.MovementVector.y);
        }
    } 
}
