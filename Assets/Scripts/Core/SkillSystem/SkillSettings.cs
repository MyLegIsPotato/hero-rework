using System.Collections.Generic;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    [CreateAssetMenu(fileName = "SkillSettings", menuName = "SkillSettings", order = 0)]
    public class SkillSettings : ScriptableObject
    {
        public float Duration;
        public float Cooldown;
        public float EffectiveRange;
        public float Damage;
        public float ProjectileSpeed;
        public bool AutoAttack;
        public List<AudioClip> SkillSounds;
        public Color SkillColor;
        public Sprite SkillIcon;
        public Color SkillBackground;
    }
}
