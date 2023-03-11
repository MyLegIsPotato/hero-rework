using System;
using Project.Core.EnemiesSystem;
using UnityEngine;

namespace Project.Gameplay.Enemies
{
    public class Dummy : MonoBehaviour, IDamagable
    {
        [SerializeField]
        private float healthPoints = 100;
        [SerializeField]
        private HealthPointsDisplay healthPointsDisplay;
        public float HealthPoints => healthPoints;

        public void TakeDamage(IDamaging damaging, float damage)
        {
            healthPoints -= damage;
            healthPoints = Mathf.Clamp(healthPoints, 0, 100);
            healthPointsDisplay.UpdateText(healthPoints.ToString());
            if (healthPoints <= 0)
            {
                OnHealthZero?.Invoke();
            }
        }

        public event Action OnHealthZero;

        private void Awake()
        {
            healthPointsDisplay.UpdateText(healthPoints.ToString());
        }
    }
}
