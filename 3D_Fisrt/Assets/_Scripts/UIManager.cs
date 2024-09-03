using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public List<Button> buttons; // Danh s�ch c�c button
    public Color selectedColor = Color.green; // M�u khi button ???c ch?n
    public Color deselectedColor = Color.white; // M�u khi button kh�ng ???c ch?n
    public Color deselectedColorImage = Color.white; // M�u khi image button kh�ng ???c ch?n
    private Button selectedButton; // Button hi?n t?i ?ang ???c ch?n
    public GameObject[] menuPanels; // M?ng ch?a t?t c? c�c panel
    private GameObject activePanel; // Panel hi?n t?i ?ang m?

    private void Start()
    {
        // ??m b?o t?t c? c�c panel ban ??u ??u b? ?�ng
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
        // ??t m�u ban ??u cho t?t c? c�c button
        foreach (Button button in buttons)
        {
            SetButtonColor(button, deselectedColor);
        }
        //Mo menuHome khi vua vao
        if (buttons.Count > 0)
        {
            selectedButton = buttons[0]; // Button ??u ti�n ???c ch?n
            SetButtonColor(selectedButton, selectedColor);
            SetChildImageColor(selectedButton, selectedColor); // ??i m�u c?a Image con
            OpenPanel(0); // M? panel ??u ti�n
        }
    }

    public void OpenPanel(int panelIndex)
    {
        // N?u c� panel ?ang m?, ?�ng n� l?i
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        // M? panel m?i v� ??t n� l� panel ?ang ho?t ??ng
        activePanel = menuPanels[panelIndex];
        activePanel.SetActive(true);
    }
    private void OnButtonClick(Button button)
    {
        // ??i m�u cho button ???c ch?n
        if (selectedButton != null)
        {
            SetButtonColor(selectedButton, deselectedColor);
            SetChildImageColor(selectedButton, deselectedColorImage); // Reset m�u cho Image con
        }

        selectedButton = button;
        SetButtonColor(selectedButton, selectedColor);
        SetChildImageColor(selectedButton, selectedColor); // ??i m�u cho Image con
    }

    private void SetButtonColor(Button button, Color color)
    {
        button.GetComponent<Image>().color = color; // �p d?ng m�u m?i cho Image c?a button
    }

    private void SetChildImageColor(Button button, Color color)
    {
        // T�m ??i t??ng con c?a Button c� component Image
        Image childImage = button.transform.GetChild(0).GetComponent<Image>();
        if (childImage != null)
        {
            Debug.Log("Changing color of: " + childImage.gameObject.name); // Ki?m tra xem ?�ng ??i t??ng kh�ng
            childImage.color = color; // ??i m�u c?a Image con
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


