using System;
using Project.Core.SkillSystem;
using UnityEngine;

namespace Project.Gameplay.SkillSystem.Skills
{
    public class SkillElectricZone : Skill
    {
        [SerializeField, Range(0.5f, 10f)]
        private float zoneRadius = 2f;

        public void OnValidate()
        {
            UpdateSize();
        }

        public void Awake()
        {
            UpdateSize();
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
                
            Debug.Log("Electric Zone!");
        }
    }
}
