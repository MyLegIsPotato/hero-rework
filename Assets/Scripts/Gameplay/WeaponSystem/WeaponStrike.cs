using System;
using Project.Core.EnemiesSystem;
using UnityEngine;

namespace Project.Gameplay.WeaponSystem
{
    public class WeaponStrike : MonoBehaviour, IDamaging
    {
        [field: SerializeField]
        public float DamagePoints { get; set; }
        
        public void Damage(IDamagable damagable)
        {
            damagable.TakeDamage(this, DamagePoints);
        }
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(this, DamagePoints);
            }
        }
    }
}
