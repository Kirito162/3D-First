using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameChanger : MonoBehaviour
{
    public InputField nameInputField; // Tham chi?u t?i InputField
    public TextMeshProUGUI playerNameText; // Tham chi?u t?i Text hi?n th? tên nhân v?t
    private string playerNameKey = "PlayerName"; // Khóa l?u tên nhân v?t
    public GameObject panelRename;

    void Start()
    {
        // Load tên nhân v?t t? PlayerPrefs khi game b?t ??u
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            playerNameText.text = PlayerPrefs.GetString(playerNameKey);
        }
    }

    public void OnConfirmButtonClicked()
    {
        // L?y giá tr? t? InputField
        string newName = nameInputField.text;

        // C?p nh?t Text hi?n th? tên nhân v?t
        playerNameText.text = newName;

        // L?u tên m?i vào PlayerPrefs
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
