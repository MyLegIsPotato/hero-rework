using UnityEngine;

public class ZoneAttackDetector : MonoBehaviour
{
    private Enemy enemy;
    
   private void Start()
{
    Enemy enemy = GetComponent<Enemy>();
    enemy.Setup();
}



    public void Setup(Enemy enemy)
    {
        this.enemy = enemy;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        ZoneAttack zoneAttack = other.gameObject.GetComponent<ZoneAttack>();
        if (zoneAttack == null || enemy == null)
        {
            Debug.LogWarning("Enemy object is not set!");
            return;
        }
       
       
      
      
        zoneAttack.OnZoneBurned += enemy.ZoneAttack_OnZoneAttacked;
        print("test");
    }

    private void OnTriggerExit(Collider other)
    {
        ZoneAttack zoneAttack = other.gameObject.GetComponent<ZoneAttack>();
        if (zoneAttack == null)
        return;

        zoneAttack.OnZoneBurned -= enemy.ZoneAttack_OnZoneAttacked;
    }
}
