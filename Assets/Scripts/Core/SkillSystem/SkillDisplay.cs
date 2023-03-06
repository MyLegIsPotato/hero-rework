using UnityEngine;
using UnityEngine.UI;

namespace Project.Core.SkillSystem
{

    public class SkillDisplay : MonoBehaviour
    {
        public const float FILL_AMOUNT = 0.25f;
        
        [SerializeField]
        private Image northFill;
        [SerializeField]
        private Image northSkillImage;
        
        [SerializeField]
        private Image southFill;
        [SerializeField]
        private Image southSkillImage;
        
        [SerializeField]
        private Image eastFill;
        [SerializeField]
        private Image eastSkillImage;
        
        [SerializeField]
        private Image westFill;
        [SerializeField]
        private Image westSkillImage;

        private Skillset skillset;
        
        public void Setup(Skillset skillset)
        {
            Debug.Log("Setting up skill display");
            this.skillset = skillset;
            
            northSkillImage.sprite = this.skillset.NorthSkill.skillSettings.SkillIcon;
            northFill.fillAmount = 0;
            skillset.NorthSkill.OnRechargeUpdated += (fraction) => UpdateFillImage(fraction, northFill);
            
            southSkillImage.sprite = this.skillset.SouthSkill.skillSettings.SkillIcon;
            southFill.fillAmount = 0;
            skillset.SouthSkill.OnRechargeUpdated += (fraction) => UpdateFillImage(fraction, southFill);
            
            eastSkillImage.sprite = this.skillset.EastSkill.skillSettings.SkillIcon;
            eastFill.fillAmount = 0;
            skillset.EastSkill.OnRechargeUpdated += (fraction) => UpdateFillImage(fraction, eastFill);
            
            westSkillImage.sprite = this.skillset.WestSkill.skillSettings.SkillIcon;
            westFill.fillAmount = 0;
            skillset.WestSkill.OnRechargeUpdated += (fraction) => UpdateFillImage(fraction, westFill);
        }

        public void UpdateFillImage(float fraction, Image image)
        {
            Debug.Log(image.name + " " + fraction);
            image.fillAmount = fraction * FILL_AMOUNT;
        }
    }
}
