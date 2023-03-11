using System;
using Project.Core.EnemiesSystem;
using Project.Core.SkillSystem;
using Project.Gameplay.WeaponSystem;
using UnityEngine;

namespace Project.Gameplay.SkillSystem.Skills
{
    public class SkillElectricZone : Skill, ISkillOffensive
    {
        [SerializeField, Range(0.5f, 10f)]
        private float zoneRadius = 2f;
        [SerializeField]
        private WeaponAOE WeaponAoe;
        
        public IDamaging DamagingObject { get; }

        private void OnValidate()
        {
            UpdateSize();
            WeaponAoe.DamagePoints = skillSettings.Damage;
        }

        private void Awake()
        {
            UpdateSize();
            WeaponAoe.DamagePoints = skillSettings.Damage;
        }

        private void UpdateSize()
        {
            transform.localScale = Vector3.one * zoneRadius;
        }

        public override void UseSkill()
        {
            if(skillTimer.TimeToFinish > 0)
                return;
            skillTimer.Reset();
            
            WeaponAoe.DamageAll();
            Debug.Log("Electric Zone!");
        }
    }
}
