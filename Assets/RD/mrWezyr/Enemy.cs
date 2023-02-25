using UnityEngine;

[RequireComponent(typeof(ZoneAttackDetector),typeof(BulletAttackDetector))]
public class Enemy : MonoBehaviour
{
    private ZoneAttackDetector zoneAttackDetector;
    public BulletAttackDetector bulletAttackDetector;
    public float health = 100;

    private void Awake()
    {
        zoneAttackDetector = GetComponent<ZoneAttackDetector>();
        bulletAttackDetector = GetComponent<BulletAttackDetector>();
    }

    public void Setup()
    {
        zoneAttackDetector.Setup(this);
        bulletAttackDetector.Setup(this);
    }

    public void ZoneAttack_OnZoneAttacked(float damage)
    {
        GetDamage(damage);
    }

    public void GetDamage(float damage)
    {
        Debug.Log("I'm " + gameObject.name + " hit with: " + damage);

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I'm dead!");
        Destroy(gameObject);
    }

}