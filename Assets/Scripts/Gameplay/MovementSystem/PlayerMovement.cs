using Project.Core.Input;
using UnityEngine;

namespace Project.Gameplay
{
    public class PlayerMovement : MovementSystem
    {
        public InputVisualizer inputVisualizer;
        private MyPlayerInput myPlayerInput;

        public void Setup(MyPlayerInput myPlayerInput)
        {
            this.myPlayerInput = myPlayerInput;
            inputVisualizer.Setup(this.myPlayerInput);
        }

        private void Update()
        {
            if(myPlayerInput == null)
                return;
            
            this.transform.position += new Vector3(
                myPlayerInput.MovementVector.x * Speed * Time.deltaTime, 
                0,
                myPlayerInput.MovementVector.y * Speed * Time.deltaTime);
        }
    }
}