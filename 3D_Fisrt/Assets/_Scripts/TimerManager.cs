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
    private WaitForSeconds waitForSeconds = new WaitForSeconds(1f); // Th?i gian ch? gi?a m?i l?n c?p nh?t gi�y

    private void Start()
    {
        // B?t ??u ??m th?i gian b?ng coroutine
        timerCoroutine = StartCoroutine(UpdateTimer());
    }

    // Coroutine c?p nh?t th?i gian m?i gi�y
    private IEnumerator UpdateTimer()
    {
        while (!isGameEnded)
        {
            elapsedTime += 1f; // C?ng th�m 1 gi�y m?i l?n
            textTimeRunning.text = GetFormattedTime(); // C?p nh?t th?i gian ch?y tr�n UI
            yield return waitForSeconds; // Ch? 1 gi�y r?i ti?p t?c c?p nh?t
        }
    }

    public string GetFormattedTime()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
    }

    // H�m g?i khi k?t th�c game
    public void StopTimer()
    {
        if (timerCoroutine != null) // Ki?m tra n?u coroutine ?ang ch?y
        {
            StopCoroutine(timerCoroutine); // D?ng coroutine ngay l?p t?c
        }

        isGameEnded = true; // ??t tr?ng th�i game ?� k?t th�c
        finalTimeFormatted = GetFormattedTime(); // L?u th?i gian cu?i c�ng
        textTimeStopped.text = finalTimeFormatted; // Hi?n th? th?i gian d?ng tr�n UI
    }

    // H�m ?? l?y th?i gian cu?i c�ng khi k?t th�c game
    public string GetFinalTime()
    {
        return finalTimeFormatted;
    }
}
