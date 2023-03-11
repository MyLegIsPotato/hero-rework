using System;
using System.Collections.Generic;
using UnityEngine;

namespace RD.lel
{
    public class WeaponAOE : MonoBehaviour, IDamaging
    {
        [SerializeField]
        private float damagePoints = 10;

        public float DamagePoints => damagePoints;
        
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
                var randomIndex = UnityEngine.Random.Range(0, damagablesInRange.Count);
                Damage(damagablesInRange[randomIndex]);
            }
        }
        
        public void Damage(IDamagable damagable)
        {
            damagable.TakeDamage(this, DamagePoints);
            Debug.Log("I have damaged the damagable: " + damagable);
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
    }
}
