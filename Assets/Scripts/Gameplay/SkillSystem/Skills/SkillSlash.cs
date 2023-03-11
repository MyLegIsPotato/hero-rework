using System;
using Project.Common.Transforms;
using Project.Core.EnemiesSystem;
using Project.Core.SkillSystem;
using Project.Gameplay.WeaponSystem;
using UnityEngine;

namespace Project.Gameplay.SkillSystem.Skills
{
    public class SkillSlash : Skill, ISkillOffensive
    {
        [SerializeField]
        private Rotator slashRotator;
        [SerializeField]
        private WeaponStrike weaponStrike;
        [SerializeField]
        private ParticleSystem VFX;
        
        public IDamaging DamagingObject { get; }
        
        private void Awake()
        {
            weaponStrike.DamagePoints = skillSettings.Damage;
            var mainVFX = VFX.main;
            mainVFX.loop = false;
        }

        public override void UseSkill()
        {
            if(skillTimer.TimeToFinish > 0)
                return;
            skillTimer.Reset();

            VFX.Clear();
            VFX.Play();
            slashRotator.StartSpin();
        }
    }
}
