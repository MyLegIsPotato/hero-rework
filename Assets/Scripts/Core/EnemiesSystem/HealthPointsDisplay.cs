using TMPro;
using UnityEngine;

namespace Project.Core.EnemiesSystem
{
    [RequireComponent(typeof(TMP_Text))]
    public class HealthPointsDisplay : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;
        
        private IDamagable damagable;

        public void OnValidate()
        {
            if (text == null)
                text = GetComponent<TMP_Text>();
        }

        public void UpdateText(string newValue)
        {
            text.SetText(newValue);
        }
        
        private void LateUpdate()
        {
            //TODO: Change from main camera to something else I guess?
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }
}
