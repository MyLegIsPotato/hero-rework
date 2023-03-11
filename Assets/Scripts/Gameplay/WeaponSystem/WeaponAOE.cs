using System.Collections.Generic;
using Project.Core.EnemiesSystem;
using UnityEngine;

namespace Project.Gameplay.WeaponSystem
{
    public class WeaponAOE : MonoBehaviour, IDamaging
    {
        [field: SerializeField]
        public float DamagePoints { get; set; }
        
        public List<IDamagable> damagablesInRange = new List<IDamagable>();

        public void DamageAll()
        {
            foreach (var damagable in damagablesInRange)
            {
                Damage(damagable);
            }
        }
        
        public void DamageRandom()
        {
            if (damagablesInRange.Count > 0)
            {
                var randomIndex = Random.Range(0, damagablesInRange.Count);
                Damage(damagablesInRange[randomIndex]);
            }
        }
        
        public void Damage(IDamagable damagable)
        {
            damagable.TakeDamage(this, DamagePoints);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagablesInRange.Add(damagable);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
            {
                damagablesInRange.Remove(damagable);
            }
        }

        private void DamagableKilled(IDamagable killedDamagable)
        {
            Debug.Log(killedDamagable + " has been killed!");
        }
    }
}
