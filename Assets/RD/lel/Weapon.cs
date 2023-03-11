using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RD.lel
{
    public class Weapon : MonoBehaviour, IDamaging
    {
        [SerializeField]
        private float damagePoints = 10;

        public float DamagePoints => damagePoints;
 
    }
}
