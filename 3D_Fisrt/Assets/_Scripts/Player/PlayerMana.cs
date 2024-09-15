using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour
{
    public int mana;
    public Slider ManaBar;
    public TextMeshProUGUI textMana;
    public PlayerData playerData;

    public void OnEnable()
    {
        mana = playerData.mana;
        ManaBar.maxValue = mana;
        ChangeManaBar();
        InvokeRepeating("Rest", 5, 10);
    }

    public void TakeMana(int manaAmount)
    {
        mana -= manaAmount;
        if(mana > ManaBar.maxValue)
        {
            mana = (int)ManaBar.maxValue;
        }
        ChangeManaBar();
        
    }


    public void ChangeManaBar()
    {
        ManaBar.value = mana;
        textMana.text = mana + "/" + ManaBar.maxValue;
    }
    public void Rest()
    {
        mana += Mathf.RoundToInt(ManaBar.maxValue / 20);
        if(mana > (int)ManaBar.maxValue) 
        {
            mana = (int)ManaBar.maxValue;
        }
        ChangeManaBar();
    }

}
