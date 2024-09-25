using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyObjects = new List<GameObject>();
    [SerializeField] List<GameObject> stoneObjects = new List<GameObject>();
    [SerializeField] private int baseGoldReward = 100; // Th??ng vàng c? b?n
    /*[SerializeField] private int totalEnemies;
    [SerializeField] private int totalStoneTowers;*/
    [SerializeField] private WinPanelManager winPanelManager;
    [SerializeField] private TimerManager timerManager;
    [SerializeField] GoldManager goldManager;
    [SerializeField] private int requiredStoneTowers;
    [SerializeField] private string requiredTime = "00:05:00"; // Th?i gian yêu c?u nh?p t? Inspector (5 phút)
    int enemyKill = 0;

    private TimeSpan requiredTimeSpan;

    private void Start()
    {
        
        // Chuy?n ??i chu?i requiredTime thành TimeSpan ?? d? dàng so sánh
        requiredTimeSpan = TimeSpan.Parse(requiredTime);

        enemyObjects.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        stoneObjects.AddRange(GameObject.FindGameObjectsWithTag("Stone"));
        /*totalEnemies = enemyObjects.Count;
        totalStoneTowers = stoneObjects.Count;*/
        enemyKill = enemyObjects.Count;
    }

    public void OnEnemyDefeated()
    {
        StartCoroutine(DelayOnEnemyDefeated());
    }

    private IEnumerator DelayOnEnemyDefeated()
    {
        yield return new WaitForSeconds(3); 

        enemyObjects.RemoveAll(item => item == null);
        //totalEnemies = enemyObjects.Count;
        if (enemyObjects.Count <= 0)
        {
            CheckWinCondition();
        }
    }
    public void OnStoneTowerDestroyed()
    {
        StartCoroutine(DelayOnStoneTowerDestroyed());
    }

    private IEnumerator DelayOnStoneTowerDestroyed()
    {
        yield return new WaitForSeconds(3); 

        stoneObjects.RemoveAll(item => item == null);
        //totalStoneTowers = stoneObjects.Count;
        if (stoneObjects.Count <= 0)
        {
            ShowLossPanel();
        }
    }

    private void CheckWinCondition()
    {
        timerManager.StopTimer(); 
        string timeFormatted = timerManager.GetFinalTime(); 
        TimeSpan completedTimeSpan = TimeSpan.Parse(timeFormatted); 

        bool[] starConditions = new bool[3];
        starConditions[0] = true;
        starConditions[1] = stoneObjects.Count >= requiredStoneTowers; 
        starConditions[2] = completedTimeSpan <= requiredTimeSpan; 
        

        int stars = CalculateStars(starConditions);
        int goldReward = baseGoldReward * stars;
        goldManager.AddGold(goldReward);
        winPanelManager.ShowWinPanel(stars, goldReward, timerManager.GetFormattedTime(), starConditions, enemyKill - enemyObjects.Count, stoneObjects.Count);
        string currentChapterKey = SceneManager.GetActiveScene().name;

        for (int i = 0; i < starConditions.Length; i++)
        {
            int checkStart = 0;
            if (starConditions[i])
            {
                checkStart = 1; //1 = true(sao da dat duoc), 0 = fasle(chua dat duoc)
            }
            PlayerPrefs.SetInt(currentChapterKey + i, checkStart);
        }
        PlayerPrefs.SetInt(currentChapterKey, stars);
        PlayerPrefs.Save();
    }

    private int CalculateStars(bool[] conditions)
    {
        int stars = 0; 
        foreach (bool condition in conditions)
        {
            if (condition) stars++;
        }
        return stars;
    }


    public void ShowLossPanel()
    {
        timerManager.StopTimer(); 
        string timeFormatted = timerManager.GetFinalTime(); 
        winPanelManager.ShowLossPanel(timeFormatted, enemyKill - enemyObjects.Count, stoneObjects.Count); 
    }
    public void ShowSoundSetting(int index)
    {
        Singleton.Instance.UIManager.OpenPanel(index);
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
