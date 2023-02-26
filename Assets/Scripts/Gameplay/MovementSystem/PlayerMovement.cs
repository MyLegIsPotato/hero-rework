using Project.Core.Input;
using UnityEngine;

namespace Project.Gameplay
{
    public class PlayerMovement : MovementSystem
    {
        public InputVisualizer inputVisualizer;
        private PlayerInput playerInput;

        public void Setup(PlayerInput playerInput)
        {
            this.playerInput = playerInput;
            inputVisualizer.Setup(this.playerInput);
        }

        private void Update()
        {
            this.transform.position += new Vector3(
                playerInput.MovementVector.x * Speed * Time.deltaTime, 
                0,
                playerInput.MovementVector.y * Speed * Time.deltaTime);
        }
    }
}