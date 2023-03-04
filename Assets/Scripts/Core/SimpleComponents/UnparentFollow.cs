using UnityEngine;

namespace Project.Core.SimpleComponents
{
    public class UnparentFollow : MonoBehaviour
    {
        private Transform parent;

        private void Awake()
        {
            parent = transform.parent;
            transform.SetParent(null);
        }

        private void Update()
        {
            if (parent != null)
                transform.position = parent.position;
        }
    }
}