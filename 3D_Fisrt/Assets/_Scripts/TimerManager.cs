using TMPro;
using UnityEngine;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTimeRunning; 
    [SerializeField] private TextMeshProUGUI textTimeStopped; 
    private float elapsedTime = 0f;
    private bool isGameEnded = false;
    private string finalTimeFormatted;
    private Coroutine timerCoroutine; // ?? l?u coroutine ?ang ch?y
    private WaitForSeconds waitForSeconds = new WaitForSeconds(1f); // Th?i gian ch? gi?a m?i l?n c?p nh?t giây

    private void Start()
    {
        // B?t ??u ??m th?i gian b?ng coroutine
        timerCoroutine = StartCoroutine(UpdateTimer());
    }

    // Coroutine c?p nh?t th?i gian m?i giây
    private IEnumerator UpdateTimer()
    {
        while (!isGameEnded)
        {
            elapsedTime += 1f; // C?ng thêm 1 giây m?i l?n
            textTimeRunning.text = GetFormattedTime(); // C?p nh?t th?i gian ch?y trên UI
            yield return waitForSeconds; // Ch? 1 giây r?i ti?p t?c c?p nh?t
        }
    }

    public string GetFormattedTime()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    }

    // Hàm g?i khi k?t thúc game
    public void StopTimer()
    {
        if (timerCoroutine != null) // Ki?m tra n?u coroutine ?ang ch?y
        {
            StopCoroutine(timerCoroutine); // D?ng coroutine ngay l?p t?c
        }

        isGameEnded = true; // ??t tr?ng thái game ?ã k?t thúc
        finalTimeFormatted = GetFormattedTime(); // L?u th?i gian cu?i cùng
        textTimeStopped.text = finalTimeFormatted; // Hi?n th? th?i gian d?ng trên UI
    }

    // Hàm ?? l?y th?i gian cu?i cùng khi k?t thúc game
    public string GetFinalTime()
    {
        return finalTimeFormatted;
    }
}
