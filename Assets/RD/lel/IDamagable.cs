using System;
using UnityEngine;

namespace RD.lel
{
    public interface IDamagable
    {
        float HealthPoints { get; }
        void TakeDamage(IDamaging damaging, float damage);

        event Action OnHealthZero;
    }
}
