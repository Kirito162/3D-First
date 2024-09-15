using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameChanger : MonoBehaviour
{
    public InputField nameInputField; // Tham chi?u t?i InputField
    public TextMeshProUGUI playerNameText; // Tham chi?u t?i Text hi?n th? t�n nh�n v?t
    private string playerNameKey = "PlayerName"; // Kh�a l?u t�n nh�n v?t
    public GameObject panelRename;

    void Start()
    {
        // Load t�n nh�n v?t t? PlayerPrefs khi game b?t ??u
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            playerNameText.text = PlayerPrefs.GetString(playerNameKey);
        }
    }

    public void OnConfirmButtonClicked()
    {
        // L?y gi� tr? t? InputField
        string newName = nameInputField.text;

        // C?p nh?t Text hi?n th? t�n nh�n v?t
        playerNameText.text = newName;

        // L?u t�n m?i v�o PlayerPrefs
        PlayerPrefs.SetString(playerNameKey, newName);
        PlayerPrefs.Save();
    }
    public void ClosePanelRename()
    {
        panelRename.SetActive(false);
    }
    public void OpenPanelRename()
    {
        panelRename.SetActive(true);
    }
}
