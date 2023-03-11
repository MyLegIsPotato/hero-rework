using System;

namespace Project.Core.EnemiesSystem
{
    public interface IDamagable
    {
        float HealthPoints { get; }
        void TakeDamage(IDamaging damaging, float damage);

        event Action OnHealthZero;
    }
}
