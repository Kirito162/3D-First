using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyManager : MonoBehaviour
{
    public List<GameObject> allAllies; // Danh s�ch ch?a c�c GameObject ally
    public List<int> costAllies;
    private Dictionary<GameObject, int> ownedAllies = new Dictionary<GameObject, int>();
    // List of Text UI elements for each ally
    public List<Text> allyCountTexts; // Danh s�ch c�c Text t??ng ?ng v?i ally ?? hi?n th? s? l??ng
    public Transform spawnPoint; // V? tr� spawn ally
    private Dictionary<GameObject, int> displayAllies = new Dictionary<GameObject, int>(); // L?u s? l??ng hi?n th? t?m th?i

    public GoldManager goldManager; // Tham chi?u t?i GoldManager

    public Dictionary<GameObject, int> allyPrices = new Dictionary<GameObject, int>(); // B?ng gi� cho t?ng lo?i Ally

    private void Start()
    {
        for (int i = 0; i < allAllies.Count; i++)
        {
            allyPrices.Add(allAllies[i], costAllies[i]);
        }
        // Kh?i t?o gi� cho m?i lo?i ally (thay gi� tr? t�y v�o game c?a b?n)
        /*allyPrices.Add(allAllies[0], 100); // Ally 1 gi� 100 gold
        allyPrices.Add(allAllies[1], 200); // Ally 2 gi� 200 gold*/

        foreach (var ally in allAllies)
        {
            string key = ally.name + "_count";
            int count = PlayerPrefs.GetInt(key, 0); // L?y d? li?u l?u tr? ho?c m?c ??nh l� 0
            ownedAllies.Add(ally, count);
            displayAllies.Add(ally, count); // Sao ch�p s? l??ng ?? hi?n th? ban ??u
        }
        // C?p nh?t s? l??ng ban ??u
        UpdateAllyCountUI();
    }

    public void PurchaseAlly(GameObject ally)
    {
        int price = allyPrices.ContainsKey(ally) ? allyPrices[ally] : 0;

        // Ki?m tra n?u ?? v�ng ?? mua ally
        if (goldManager.SpendGold(price))
        {
            if (ownedAllies.ContainsKey(ally))
            {
                ownedAllies[ally]++;
            }
            else
            {
                ownedAllies.Add(ally, 1);
            }
            SaveAllyData();
            UpdateAllyCountUI();
        }
        else
        {
            Debug.Log("Not enough gold to purchase this ally!");
        }
    }

    public int GetAllyCount(GameObject ally)
    {
        if (ownedAllies.ContainsKey(ally))
        {
            return ownedAllies[ally];
        }
        return 0;
    }

    public void SaveAllyData()
    {
        foreach (var ally in ownedAllies)
        {
            string key = ally.Key.name + "_count"; // S? d?ng t�n c?a GameObject l�m kh�a
            PlayerPrefs.SetInt(key, ally.Value);
        }
        PlayerPrefs.Save();
    }

    // H�m ?? c?p nh?t UI hi?n th? s? l??ng ally
    private void UpdateAllyCountUI()
    {
        for (int i = 0; i < allAllies.Count; i++)
        {
            GameObject ally = allAllies[i];
            int count = GetAllyCount(ally);

            // C?p nh?t text c?a ally t??ng ?ng
            allyCountTexts[i].text = ally.name + ": " + count.ToString();
        }
    }

    // Spawn ally khi nh?n n�t
    public void SpawnAlly(GameObject ally)
    {
        // Ki?m tra n?u s? l??ng ally c�n l?i ?? spawn
        if (displayAllies.ContainsKey(ally) && displayAllies[ally] > 0)
        {
            Instantiate(ally, spawnPoint.position + spawnPoint.forward * 5, spawnPoint.transform.rotation); // Spawn ally t?i v? tr� spawnPoint

            displayAllies[ally]--; // Tr? ?i 1 s? l??ng hi?n th?
            UpdateAllyCountUI_InCombat(); // C?p nh?t l?i UI
        }
        else
        {
            Debug.Log("Kh�ng c�n ally n�o ?? spawn!");
            UpdateAllyCountUI_InCombat();
        }
    }

    private void UpdateAllyCountUI_InCombat()
    {
        for (int i = 0; i < allAllies.Count; i++)
        {
            GameObject ally = allAllies[i];
            int count = displayAllies[ally]; // L?y s? l??ng t?m th?i ?ang hi?n th?

            allyCountTexts[i].text = ally.name + ": " + count.ToString();
        }
    }

    public void OnOff_MenuAllly()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
