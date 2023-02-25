using System;
using UnityEngine;
public class BulletAttackDetector : MonoBehaviour
{
    private Enemy enemy;

    public Action<float> OnBulletHit;

    public void Setup(Enemy enemy)
    {
        this.enemy = enemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            // Debug.Log("Bullet hit me!");
            enemy.GetDamage(collision.collider.GetComponent<Bullet>().damage);
            Destroy(collision.collider.gameObject);
        }
    }
}
