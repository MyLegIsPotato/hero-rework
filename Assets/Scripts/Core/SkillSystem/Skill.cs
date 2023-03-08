using System;
using Project.Common.Time;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public abstract class Skill : MonoBehaviour
    {
        public float RechargeFraction { get; private set; }
        
        public SkillSettings skillSettings;
        public Timer skillTimer;

        public Action<float> OnRechargeUpdated;

        public SkillSlot AssignedSlot;
        public int SkillIndex;
        
        public void ActivateSkill()
        {
            skillTimer = new Timer(skillSettings.Cooldown, skillSettings.AutoAttack);
            if(skillSettings.AutoAttack)
                skillTimer.OnTimerFinished += UseSkill;

            skillTimer.OnTimerUpdated += (fraction) => OnRechargeUpdated.Invoke(fraction);
            RechargeFraction = 0;
        }
        
        public void DeactivateSkill()
        {
            skillTimer.OnTimerUpdated -= (fraction) => OnRechargeUpdated.Invoke(fraction);
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

        public virtual void UseSkill()
        {
            if(skillTimer.TimeToFinish > 0)
               return;
            
            Debug.Log("Skill used");
            skillTimer.Reset();
        }
    }
}
