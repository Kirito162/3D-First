using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] starConditionTexts; // Text cho ?i?u ki?n m?i sao
    [SerializeField] private TextMeshProUGUI goldRewardText;       // Text hi?n th? s? vàng nh?n ???c
    [SerializeField] private TextMeshProUGUI timeText;             // Text hi?n th? th?i gian hoàn thành
    [SerializeField] private TextMeshProUGUI winOrLoseText;        // Text ghi "Win" ho?c "Lost"
    [SerializeField] private TextMeshProUGUI enemyKill;
    [SerializeField] private TextMeshProUGUI stoneCount;
    [SerializeField] private GameObject winPanel;                  // Panel Win ho?c thua
    [SerializeField] private Image[] starImages;                   // Hình ?nh các sao (3 sao)
    
    // Hi?n th? panel khi th?ng
    public void ShowWinPanel(int stars, int goldReward, string timeFormatted, bool[] starConditions, int enemyKillCount, int stoneEnergyCount)
    {
        winPanel.SetActive(true);  // Hi?n th? panel
        winOrLoseText.text = "WIN";  // C?p nh?t ch? Win
        winOrLoseText.color = Color.green;
        for (int i = 0; i < starConditionTexts.Length; i++)
        {
            starConditionTexts[i].color = starConditions[i] ? Color.yellow : Color.black; // ?i?u ki?n nào ??t ???c s? ??i màu vàng
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
        winOrLoseText.text = "LOSS";  // ??i thành ch? "Lost"
        winOrLoseText.color = Color.red;

        for (int i = 0; i < starConditionTexts.Length; i++)
        {
            starConditionTexts[i].color = Color.black; // T?t c? các dòng ?i?u ki?n không ??i màu vàng
        }

        for (int i = 0; i < starImages.Length; i++)
        {
            starImages[i].color = Color.black; // Hi?n th? 3 sao tr?ng (t?c là 0 sao)
        }
        stoneCount.text = "Remaining Energy Pillars: " + stoneEnergyCount;
        enemyKill.text = "Enemys Killed: " + enemyKillCount;
        goldRewardText.text = "Golds reward: 0";  // Vàng nh?n ???c b?ng 0
        timeText.text = "Time: " + timeFormatted;  // Hi?n th? th?i gian ch?i
        
    }

    
}
