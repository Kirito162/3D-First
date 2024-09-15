using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private List<string> tipsList; // Danh sách ch?a các tips
    [SerializeField] private TextMeshProUGUI tipsText; // Text UI ?? hi?n th? tip
    [SerializeField] private float interval = 10f; // Kho?ng th?i gian gi?a các tips

    private int currentTipIndex = -1;

    private void Start()
    {
        InvokeRepeating(nameof(DisplayRandomTip), 0f, interval);
    }

    private void DisplayRandomTip()
    {
        if (tipsList.Count == 0) return;

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, tipsList.Count);
        } while (randomIndex == currentTipIndex);

        currentTipIndex = randomIndex;
        tipsText.text = tipsList[currentTipIndex];
    }
}
