using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;
using static System.Net.Mime.MediaTypeNames;

public class LevelSystem : MonoBehaviour
{
    public PlayerData playerData;
    public int baseExp = 100;   // L??ng exp c? b?n c?n thi?t cho level 1 -> level 2
    public float exponent = 2f; // H? s? m? cho công th?c tính exp
    public int level = 1;
    public int currentExp = 0;
    public Slider expBar;
    public TextMeshProUGUI textLevel;
    private void OnEnable()
    {
        UpdateExpBar();
    }
    public int CalculateRequiredExp(int level)
    {
        return Mathf.FloorToInt(baseExp * Mathf.Pow(level, exponent));
    }

    public void AddExperience(int exp)
    {
        currentExp += exp;
        expBar.value = currentExp;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredExp = CalculateRequiredExp(level);

        while (currentExp >= requiredExp)
        {
            currentExp -= requiredExp;
            level++;
            Debug.Log($"Leveled Up! New Level: {level}");
            UpdateExpBar();
        }
    }
    private void UpdateExpBar()
    {
        expBar.value = currentExp;
        int requiredExp = CalculateRequiredExp(level);
        expBar.maxValue = requiredExp;
        textLevel.text = "Level: " + level;
    }
}
