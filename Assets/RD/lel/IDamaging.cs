namespace RD.lel
{
    public interface IDamaging
    {
        float DamagePoints { get; }
        public void Damage(IDamagable damagable)
        {
            damagable.TakeDamage(DamagePoints);
        }
    }
}
