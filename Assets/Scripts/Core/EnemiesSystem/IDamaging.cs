namespace Project.Core.EnemiesSystem
{
    public interface IDamaging
    {
        float DamagePoints { get; }
        public void Damage(IDamagable damagable);
    }
}
