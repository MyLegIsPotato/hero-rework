using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Core.Input;
using TreeEditor;

namespace Project.Gameplay.AnimationSystem
{
    public class PlayerAnimation : MonoBehaviour
    {
        private const string PLAYER_FORWARD_VELOCITY = "ForwardVelocity";
        private const string PLAYER_TURN_AMOUNT = "TurnAmount";
        
        private MyPlayerInput myPlayerInput;
        private PlayerMovement playerMovement;
        private Animator anim;
        private float smoothedVelocity;
        private float smoothingFactor = 1f;
        
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
            anim.SetFloat(PLAYER_FORWARD_VELOCITY, playerMovement.movementVelocity);
            anim.SetFloat(PLAYER_TURN_AMOUNT, playerMovement.turnAmount);
        }
    } 
}