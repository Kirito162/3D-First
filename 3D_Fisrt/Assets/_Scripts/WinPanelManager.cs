using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] starConditionTexts; // Text cho ?i?u ki?n m?i sao
    [SerializeField] private TextMeshProUGUI goldRewardText;       // Text hi?n th? s? v�ng nh?n ???c
    [SerializeField] private TextMeshProUGUI timeText;             // Text hi?n th? th?i gian ho�n th�nh
    [SerializeField] private TextMeshProUGUI winOrLoseText;        // Text ghi "Win" ho?c "Lost"
    [SerializeField] private TextMeshProUGUI enemyKill;
    [SerializeField] private TextMeshProUGUI stoneCount;
    [SerializeField] private GameObject winPanel;                  // Panel Win ho?c thua
    [SerializeField] private Image[] starImages;                   // H�nh ?nh c�c sao (3 sao)
    
    // Hi?n th? panel khi th?ng
    public void ShowWinPanel(int stars, int goldReward, string timeFormatted, bool[] starConditions, int enemyKillCount, int stoneEnergyCount)
    {
        winPanel.SetActive(true);  // Hi?n th? panel
        winOrLoseText.text = "WIN";  // C?p nh?t ch? Win
        winOrLoseText.color = Color.green;
        for (int i = 0; i < starConditionTexts.Length; i++)
        {
            starConditionTexts[i].color = starConditions[i] ? Color.yellow : Color.black; // ?i?u ki?n n�o ??t ???c s? ??i m�u v�ng
        }

        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = (i < stars) ? Color.white : Color.black; // Hi?n th? s? sao ??t ???c
        }
        stoneCount.text = "Remaining Energy Pillars: " + stoneEnergyCount;
        enemyKill.text = "Enemies Killed: " + enemyKillCount;
        goldRewardText.text = "Gold reward: " + goldReward;
        timeText.text = "Time: " + timeFormatted;
        
    }

    // Hi?n th? panel khi thua
    public void ShowLossPanel(string timeFormatted, int enemyKillCount, int stoneEnergyCount)
    {
        winPanel.SetActive(true);  // Hi?n th? panel
        winOrLoseText.text = "LOSS";  // ??i th�nh ch? "Lost"
        winOrLoseText.color = Color.red;

        for (int i = 0; i < starConditionTexts.Length; i++)
        {
            starConditionTexts[i].color = Color.black; // T?t c? c�c d�ng ?i?u ki?n kh�ng ??i m�u v�ng
        }

        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = Color.black; // Hi?n th? 3 sao tr?ng (t?c l� 0 sao)
        }
        stoneCount.text = "Remaining Energy Pillars: " + stoneEnergyCount;
        enemyKill.text = "Enemys Killed: " + enemyKillCount;
        goldRewardText.text = "Golds reward: 0";  // V�ng nh?n ???c b?ng 0
        timeText.text = "Time: " + timeFormatted;  // Hi?n th? th?i gian ch?i
        
    }

    
}
