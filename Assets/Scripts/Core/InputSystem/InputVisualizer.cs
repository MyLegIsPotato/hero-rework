using UnityEngine;

namespace Project.Core.InputSystem
{
    public class InputVisualizer : MonoBehaviour
    {
        public Transform visualizerIndicator;

        [SerializeField]
        private BoxCollider visualizerPlate;

        public float visualizerRadius;

        private MyPlayerInput myPlayerInput;

        public void OnEnable()
        {
            visualizerRadius = visualizerPlate.bounds.size.z / 2;
        }

        private void OnDestroy()
        {
            if (myPlayerInput != null) myPlayerInput.OnMovementPerformed -= UpdateVisualizer;
        }

        public void Setup(MyPlayerInput myPlayerInput)
        {
            this.myPlayerInput = myPlayerInput;
            myPlayerInput.OnMovementPerformed += UpdateVisualizer;
        }

        private void UpdateVisualizer(Vector2 inputVector)
        {
            if (visualizerIndicator == null || visualizerPlate == null) return;

            var localPosition = visualizerIndicator.localPosition;
            localPosition.x = inputVector.x * visualizerRadius;
            localPosition.z = inputVector.y * visualizerRadius;
            visualizerIndicator.localPosition = localPosition;
        }
    }
}