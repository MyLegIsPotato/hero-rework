using UnityEngine;

namespace Project.Common.Transforms
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float spinSpeed = 100;
        public void Update()
        {
            Spin(spinSpeed * UnityEngine.Time.deltaTime);
        }
        
        public void Spin(float spinDelta)
        {
            transform.Rotate(Vector3.up, spinDelta);
        }
    }
}
