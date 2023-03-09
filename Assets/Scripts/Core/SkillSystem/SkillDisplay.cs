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

        [SerializeField]
        private Image[] indicators;
        
        private RectTransform skillDebugIndicator;
        
        public void UpdateFillImage(int slotIndex, float fraction)
        {
            fillImages[slotIndex].fillAmount = fraction * FILL_AMOUNT;
        }

        public void SetSkillAppearence(int slotIndex, Skill skill)
        {
            if (skill == null)
            {
                HideSlotIcon(slotIndex);
                return;
            }
            
            skillImages[slotIndex].color = Color.white;
            fillImages[slotIndex].color = skill.skillSettings.SkillColor;
            skillImages[slotIndex].sprite = skill.skillSettings.SkillIcon;
        }
        
        public void SetIndicatorVisibility(int slotIndex)
        {
            for (int i = 0; i < indicators.Length; i++)
            {
                if(i == slotIndex)
                    indicators[i].gameObject.SetActive(true);
                else
                    indicators[i].gameObject.SetActive(false);
            }
        }

        public void HideSlotIcon(int slotIndex)
        {
            skillImages[slotIndex].color = Color.clear;
            fillImages[slotIndex].color = Color.clear;
        }

        private void SetDebugIndicatorPosition(Vector2 newPosition)
        {
            skillDebugIndicator.anchoredPosition = newPosition;
        }
    }
}