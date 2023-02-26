using UnityEngine;

namespace Project.Core.Input
{
    public class InputVisualizer : MonoBehaviour
    {
        [SerializeField]
        private Transform visualizerIndicator;
        [SerializeField]
        private BoxCollider visualizerPlate;

        public void Setup(PlayerInput playerInput)
        {
            playerInput.OnMovePerformed += UpdateVisualizer;
        }

        public void UpdateVisualizer(Vector2 inputVector)
        {
            if(visualizerIndicator == null || visualizerPlate == null)
                return;
        
            visualizerIndicator.localPosition = new Vector3(
                inputVector.x * visualizerPlate.bounds.size.x / 2,
                0,
                inputVector.y * visualizerPlate.bounds.size.z / 2);
        }
    }
}

