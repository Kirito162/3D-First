using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject tutorialPanel2;
    [SerializeField] private TextMeshProUGUI playerNameText; // Tham chi?u t?i Text hi?n th? tên nhân v?t
    private string playerNameKey = "PlayerName"; // Khóa l?u tên nhân v?t

    [SerializeField] private int currentStep = 0;
    private string[] tutorialSteps = {
        "Welcome you to Chapter 1!",
        "Drag the screen area to the right to rotate the camera.",
        "Destroy all enemies and protect the energy stone pillar to win.",
        "You can use the following systems to support combat: ..."
    };

    private void Start()
    {
        // Load tên nhân v?t t? PlayerPrefs khi game b?t ??u
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            playerNameText.text = PlayerPrefs.GetString(playerNameKey, "No Name");
        }
        ShowNextTutorialStep();
    }

    public void ShowNextTutorialStep()
    {
        if (currentStep < tutorialSteps.Length)
        {
            tutorialPanel.SetActive(true);
            tutorialText.text = tutorialSteps[currentStep];
            currentStep++;
        }
        else
        {
            tutorialPanel.SetActive(false); // T?t panel khi hoàn thành t?t c? các b??c h??ng d?n
            tutorialPanel2.SetActive(true);
        }
    }
    public void DisplayTutorial()
    {
        currentStep = 0;
        ShowNextTutorialStep();
        tutorialPanel.SetActive(true);
    }
    public void HidePanel2()
    {
        tutorialPanel2.SetActive(false);
    }
}
