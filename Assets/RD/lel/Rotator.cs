using UnityEngine;

namespace RD.lel
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private float spinSpeed = 100;
        public void Update()
        {
            Spin(spinSpeed * Time.deltaTime);
        }
        
        public void Spin(float spinDelta)
        {
            transform.Rotate(Vector3.up, spinDelta);
        }
    }
}
