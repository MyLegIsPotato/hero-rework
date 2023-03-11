using System;
using Project.Common.Time;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public abstract class Skill : MonoBehaviour
    {
        public SkillSlot AssignedSlot;
        public int SkillIndex;
        public SkillSettings skillSettings;
        protected Timer skillTimer;

        public event Action<int, float> OnRechargeUpdated;
        public event Action<int> OnSkillSelected;
        
        public float RechargeFraction { get; private set; }
        
        public void ActivateSkill()
        {
            skillTimer = new Timer(skillSettings.Cooldown, skillSettings.AutoAttack);
            if(skillSettings.AutoAttack)
                skillTimer.OnTimerFinished += UseSkill;

            skillTimer.OnTimerUpdated += (fraction) => OnRechargeUpdated?.Invoke(SkillIndex, fraction);
            RechargeFraction = 0;
        }
        
        public void DeactivateSkill()
        {
            skillTimer.OnTimerUpdated = null;
            skillTimer.OnTimerFinished -= UseSkill;
        }
        
        public void OnDestroy()
        {
            skillTimer.OnTimerFinished -= UseSkill;
        }

        public void Update()
        {
            skillTimer.UpdateTimer(Time.deltaTime);
        }

        public abstract void UseSkill();
    }
}
