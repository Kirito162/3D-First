using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    public PlayerData playerData; // Ch?a các tr?ng thái c?a ng??i ch?i nh? máu, s?c m?nh, v.v.
    public GoldManager goldManager;
    [SerializeField] int hpUp = 10;
    [SerializeField] int damageUp = 5;
    [SerializeField] int manaUp = 10;
    [SerializeField] TextMeshProUGUI textDamage;
    [SerializeField] TextMeshProUGUI textHP;
    [SerializeField] TextMeshProUGUI textMana;
    [SerializeField] TextMeshProUGUI textGold;
    public Slider damageBar;
    public Slider HPBar;
    public Slider ManaBar;
    //int manaSave;
    public int upgradeCost = 100;

    private void InitializeUI()
    {
        LoadStates();
/*        damageBar.maxValue = playerData.maxDamage;
        HPBar.maxValue = playerData.maxHP;
        ManaBar.maxValue = playerData.maxMana;*/
        textGold.text = "" + playerData.currentGold;
        InitState(playerData.hp, playerData.maxHP, HPBar, textHP);
        InitState(playerData.mana, playerData.maxMana, ManaBar, textMana);
        InitState(playerData.damage, playerData.maxDamage, damageBar, textDamage);
    }

    private void Start()
    {
        InitializeUI();
    }
    public void InitState(int currentStat, int maxStat, Slider statBar, TextMeshProUGUI statText)
    {
        statBar.maxValue = maxStat;
        statBar.value = currentStat;
        statText.text = currentStat + " / " + maxStat;
    }

    public void UpgradeStat(ref int currentStat, int statIncrease, int maxStat, Slider statBar, TextMeshProUGUI statText)
    {
        if (currentStat >= maxStat) { return; }
        if (goldManager.SpendGold(upgradeCost))
        {
            currentStat += statIncrease;
            Debug.Log("Stat upgraded!");
            statBar.value = currentStat;
            statText.text = currentStat + " / " + maxStat;
            textGold.text = "" + playerData.currentGold;
        }
    }
    
    public void UpgradeHealth() => UpgradeStat(ref playerData.hp, hpUp, playerData.maxHP, HPBar, textHP);
    public void UpgradeMana() => UpgradeStat(ref playerData.mana, manaUp, playerData.maxMana, ManaBar, textMana);
    public void UpgradeDamage() => UpgradeStat(ref playerData.damage, damageUp, playerData.maxDamage, damageBar, textDamage);
    public void ChangeDMG()
    {
        PlayerPrefs.SetInt("Damage", playerData.damage);
        PlayerPrefs.Save();
    }
    public void ChangeHP()
    {
        PlayerPrefs.SetInt("HP", playerData.hp);
        PlayerPrefs.Save();
    }
    public void ChangeMana()
    {
        PlayerPrefs.SetInt("Mana", playerData.mana);
        PlayerPrefs.Save();
    }
    void LoadStates()
    {
        playerData.damage = PlayerPrefs.GetInt("Damage", playerData.damage);
        playerData.hp = PlayerPrefs.GetInt("HP", playerData.hp);
        playerData.mana = PlayerPrefs.GetInt("Mana", playerData.mana);
    }
}
