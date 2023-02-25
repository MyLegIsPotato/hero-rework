using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAttack : MonoBehaviour
{
    public bool isBurning  = true;
    public float timeInterval = 0.3f;
    public float attackDamage = 10;
    public Action<float> OnZoneBurned;

    private void Start()
    {
        StartCoroutine(BurnTheZone());
    }

    private IEnumerator BurnTheZone()
    {
        while (isBurning)
        {
            //Debug.Log("Burning");
            OnZoneBurned?.Invoke(attackDamage);
            yield return new WaitForSeconds(timeInterval);
        }
        yield return null;
    }
}
