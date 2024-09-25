using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] TextMeshProUGUI textGold;
    [SerializeField] Text textShowGoldChange;

    public void Start()
    {
        InvokeRepeating("AutoGainGold", 10, 10);
        playerData.currentGold = PlayerPrefs.GetInt("Gold", 10000);
        textGold.text = "" + playerData.currentGold;
    }
    public void AddGold(int amount)
    {
        playerData.currentGold += amount;
        SaveGold();
        textGold.text = "" + playerData.currentGold;
        Singleton.Instance.UIManager.ShowPopup(textShowGoldChange, 2);
        textShowGoldChange.text = "+" + amount + " gold";
    }

    public bool SpendGold(int amount)
    {
        if (playerData.currentGold >= amount)
        {
            playerData.currentGold -= amount;
            textGold.text = "" + playerData.currentGold;
            Singleton.Instance.UIManager.ShowPopup(textShowGoldChange, 2);
            textShowGoldChange.text = "-" + amount + " gold";
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
        Singleton.Instance.UIManager.ShowPopup(textShowGoldChange, 2);
        textShowGoldChange.text = "+5 gold";
        SaveGold();
    }
    void SaveGold()
    {
        PlayerPrefs.SetInt("Gold", playerData.currentGold);
        PlayerPrefs.Save();
    }
}
