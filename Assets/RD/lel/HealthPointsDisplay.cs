using System;
using TMPro;
using UnityEngine;

namespace RD.lel
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
    }
}
