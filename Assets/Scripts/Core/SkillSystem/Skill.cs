using System;
using Project.Common.Time;
using UnityEngine;

namespace Project.Core.SkillSystem
{
    public abstract class Skill : MonoBehaviour
    {
        public SkillSettings skillSettings;
        protected Timer skillTimer;
        private int skillIndex;
        private SkillSlot skillSlot;
        
        public event Action<int, float> OnRechargeUpdated;
        public event Action<int> OnSkillSelected;
        
        public SkillSlot AssignedSlot => skillSlot;
        public int SkillIndex => skillIndex;
        public float RechargeFraction { get; private set; }
        
        private void OnDestroy()
        {
            skillTimer.OnTimerFinished -= UseSkill;
        }

        private void Update()
        {
            skillTimer.UpdateTimer(Time.deltaTime);
        }
        
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
        
        public void AssignSlot(SkillSlot skillSlot, int skillIndex)
        {
            this.skillSlot = skillSlot;
            this.skillIndex = skillIndex;
        }
        
        public abstract void UseSkill();
    }
}
