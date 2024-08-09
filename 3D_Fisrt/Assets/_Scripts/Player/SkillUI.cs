using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Text[] skillNameTexts;
    public Text[] cooldownTexts;
    public Text[] manaCostTexts;
    public Text[] damageTexts;
    public Image[] cooldownImages; // Thanh cooldown
    public SkillManager skillManager;

    private void Update()
    {
        for (int i = 0; i < skillManager.skills.Length; i++)
        {
            if (skillManager.cooldownTexts != null && i < skillManager.cooldownTexts.Length)
            {
                cooldownTexts[i].text = skillManager.skillCooldownActive[i]
                    ? $"{Mathf.Max(0, skillManager.cooldownTimers[i]):F1} s"
                    : "Ready!";

                if (cooldownImages != null && i < cooldownImages.Length)
                {
                    cooldownImages[i].fillAmount = skillManager.skillCooldownActive[i]
                        ? (skillManager.cooldownTimers[i] / skillManager.skills[i].cooldown)
                        : 0;
                }
            }
        }
    }
}
