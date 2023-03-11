using System;

namespace RD.lel
{
    public interface IDamagable
    {
        float HealthPoints { get; }
        void TakeDamage(float damage);

        event Action OnHealthZero;
    }
}
