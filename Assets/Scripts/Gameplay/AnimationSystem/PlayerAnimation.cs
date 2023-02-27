using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core.Input;
namespace Project.Gameplay.AnimationSystem
{
    public class PlayerAnimation : MonoBehaviour
    {
        private MyPlayerInput myPlayerInput;
        private PlayerMovement playerMovement;
        private Animator anim;
        
        public void Setup(MyPlayerInput myPlayerInput, PlayerMovement playerMovement)
        {
            this.myPlayerInput = myPlayerInput;
            this.playerMovement = playerMovement;
        }
        
        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        
        private void Update()
        {
            anim.SetFloat("velx", myPlayerInput.MovementVector.x);
            Debug.Log(playerMovement.movementVelocity);
            anim.SetFloat("vely", playerMovement.movementVelocity);
        }
    } 
}