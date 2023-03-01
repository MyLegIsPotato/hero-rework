using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Core.Input
{
    public class InputVisualizer : MonoBehaviour
    {
        public Transform visualizerIndicator;
        [SerializeField] private BoxCollider visualizerPlate;

        private MyPlayerInput myPlayerInput;

        [FormerlySerializedAs("visualizerBoxSize")] public Vector2 visualizerRadius;

        public void Setup(MyPlayerInput myPlayerInput)
        {
            this.myPlayerInput = myPlayerInput;
            myPlayerInput.OnMovementPerformed += UpdateVisualizer;
            visualizerRadius = visualizerPlate.bounds.size/2;
        }

        private void OnDestroy()
        {
            if (myPlayerInput != null)
            {
                myPlayerInput.OnMovementPerformed -= UpdateVisualizer;
            }
        }

        private void UpdateVisualizer(Vector2 inputVector)
        {
            if (visualizerIndicator == null || visualizerPlate == null)
            {
                return;
            }

            Vector3 localPosition = visualizerIndicator.localPosition;
            localPosition.x = inputVector.x * visualizerPlate.bounds.size.x / 2;
            localPosition.z = inputVector.y * visualizerPlate.bounds.size.z / 2;
            visualizerIndicator.localPosition = localPosition;
        }
    }
}