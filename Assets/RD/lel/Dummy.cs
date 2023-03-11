using System;
using UnityEngine;

namespace RD.lel
{
    public class Dummy : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private float healthPoints = 100;
        [SerializeField]
        private HealthPointsDisplay healthPointsDisplay;
        public float HealthPoints => healthPoints;
        
        public event Action OnHealthZero;

        private void Awake()
        {
            healthPointsDisplay.UpdateText(healthPoints.ToString());
        }

        public void TakeDamage(float damage)
        {
            healthPoints -= damage;
            healthPoints = Mathf.Clamp(healthPoints, 0, 100);
            healthPointsDisplay.UpdateText(healthPoints.ToString());
        }


        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("Entered some trigger! " + other.gameObject.name);
            if (other.TryGetComponent(out IDamaging damaging))
            {
                damaging.Damage(this);
                Debug.Log("Dummy was damaged by a weapon!");
                Debug.Log("Current HP: " + HealthPoints);
            }
        }
    }
}
