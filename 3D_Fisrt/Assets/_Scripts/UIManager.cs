using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public List<Button> buttons; 
    public Color selectedColor = Color.green; 
    public Color deselectedColor = Color.white; 
    public Color deselectedColorImage = Color.white; 
    private Button selectedButton; // Button hien tai dang duoc chon
    public GameObject[] menuPanels;
    private GameObject activePanel; // Panel hien tai dang mo

    private void Start()
    {
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }

        foreach (Button button in buttons)
        {
            SetButtonColor(button, deselectedColor);
        }
        //Mo menuHome khi vua vao
        if (buttons.Count > 0)
        {
            selectedButton = buttons[0]; 
            SetButtonColor(selectedButton, selectedColor);
            SetChildImageColor(selectedButton, selectedColor); 
            OpenPanel(0); 
        }
    }

    public void OpenPanel(int panelIndex)
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        activePanel = menuPanels[panelIndex];
        activePanel.SetActive(true);
    }
    private void OnButtonClick(Button button)
    {
        if (selectedButton != null)
        {
            SetButtonColor(selectedButton, deselectedColor);
            SetChildImageColor(selectedButton, deselectedColorImage); 
        }

        selectedButton = button;
        SetButtonColor(selectedButton, selectedColor);
        SetChildImageColor(selectedButton, selectedColor); 
    }

    private void SetButtonColor(Button button, Color color)
    {
        button.GetComponent<Image>().color = color;
    }

    private void SetChildImageColor(Button button, Color color)
    {
        Image childImage = button.transform.GetChild(0).GetComponent<Image>();
        if (childImage != null)
        {
            childImage.color = color; 
        }
        else
        {
            Debug.Log("No Image component found in children of: " + button.gameObject.name);
        }
    }

 
    //------------------------------ TEXT POPUP --------------------------------------

    //public Text popupText; // Drag the Text UI element here in the inspector
    //public float displayDuration = 2f; // Duration to display the text

    // Ensure the text starts invisible
    //popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 0);

    public void ShowPopup(Text popupText, float displayDuration)
    {
        StartCoroutine(DisplayText (popupText, displayDuration));
    }

    private IEnumerator DisplayText(Text popupText, float displayDuration)
    {
        // Set alpha to 1 (fully visible)
        popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 1);

        // Wait for the display duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out the text
        float fadeDuration = 1f;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, alpha);
            yield return null;
        }

        // Ensure the text is fully transparent after the fade
        popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 0);
    }
}


