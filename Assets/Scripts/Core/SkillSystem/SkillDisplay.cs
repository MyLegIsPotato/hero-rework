using UnityEngine;
using UnityEngine.UI;

namespace Project.Core.SkillSystem
{
    public class SkillDisplay : MonoBehaviour
    {
        public const float FILL_AMOUNT = 0.25f;

        [SerializeField]
        private Image[] fillImages;

        [SerializeField]
        private Image[] skillImages;
        
        [SerializeField]
        private Image[] backgrounds;

        private Skillset skillset;

        public void Setup(Skillset skillset)
        {
            Debug.Log("Setting up skill display");
            this.skillset = skillset;
            this.skillset.OnSkillSlotUpdated += SetSkillAppearence;
        }

        public void UpdateFillImage(float fraction, Image image)
        {
            image.fillAmount = fraction * FILL_AMOUNT;
        }

        public void SetSkillAppearence(int slotIndex, Skill skill)
        {
            if (slotIndex < 0 || slotIndex >= fillImages.Length)
            {
                Debug.LogError("Skill slot out of range");
                return;
            }
            
            skillImages[slotIndex].sprite = skillset.Skills[slotIndex].skillSettings.SkillIcon;
            fillImages[slotIndex].fillAmount = 0;
            skillset.Skills[slotIndex].OnRechargeUpdated += fraction => UpdateFillImage(fraction, fillImages[slotIndex]);
            
            fillImages[slotIndex].color = skill.skillSettings.SkillColor;
            //backgrounds[slotIndex].color = backgroundColor;
            //skillImages[slotIndex].color = skillColor;
        }
    }
}