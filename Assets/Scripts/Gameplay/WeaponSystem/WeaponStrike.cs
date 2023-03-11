using Project.Core.EnemiesSystem;
using UnityEngine;

namespace Project.Gameplay.WeaponSystem
{
    public class WeaponStrike : MonoBehaviour, IDamaging
    {
        [SerializeField]
        private float damagePoints = 10;

        public float DamagePoints => damagePoints;
        
        public void Damage(IDamagable damagable)
        {
            damagable.TakeDamage(this, DamagePoints);
            Debug.Log("I have damaged the damagable: " + damagable);
        }
    }
}
