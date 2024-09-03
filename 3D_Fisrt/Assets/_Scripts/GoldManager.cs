using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] TextMeshProUGUI textGold;

    public void Start()
    {
        InvokeRepeating("AutoGainGold", 10, 10);
        playerData.currentGold = PlayerPrefs.GetInt("Gold");
        textGold.text = "" + playerData.currentGold;
    }
    public void AddGold(int amount)
    {
        playerData.currentGold += amount;
        SaveGold();
    }

    public bool SpendGold(int amount)
    {
        if (playerData.currentGold >= amount)
        {
            playerData.currentGold -= amount;
            SaveGold();
            return true;
        }
        else
        {
            Debug.Log("Not enough gold");
            return false;
        }
    }

    public int GetCurrentGold()
    {
        return playerData.currentGold;
    }
    void AutoGainGold()
    {
        playerData.currentGold += 5;
        textGold.text = "" + playerData.currentGold;
        SaveGold();
    }
    void SaveGold()
    {
        PlayerPrefs.SetInt("Gold", playerData.currentGold);
        PlayerPrefs.Save();
    }
}
