using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public List<Button> buttons; // Danh sách các button
    public Color selectedColor = Color.green; // Màu khi button ???c ch?n
    public Color deselectedColor = Color.white; // Màu khi button không ???c ch?n
    public Color deselectedColorImage = Color.white; // Màu khi image button không ???c ch?n
    private Button selectedButton; // Button hi?n t?i ?ang ???c ch?n
    public GameObject[] menuPanels; // M?ng ch?a t?t c? các panel
    private GameObject activePanel; // Panel hi?n t?i ?ang m?

    private void Start()
    {
        // ??m b?o t?t c? các panel ban ??u ??u b? ?óng
        foreach (GameObject panel in menuPanels)
        {
            panel.SetActive(false);
        }
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
        // ??t màu ban ??u cho t?t c? các button
        foreach (Button button in buttons)
        {
            SetButtonColor(button, deselectedColor);
        }
        //Mo menuHome khi vua vao
        if (buttons.Count > 0)
        {
            selectedButton = buttons[0]; // Button ??u tiên ???c ch?n
            SetButtonColor(selectedButton, selectedColor);
            SetChildImageColor(selectedButton, selectedColor); // ??i màu c?a Image con
            OpenPanel(0); // M? panel ??u tiên
        }
    }

    public void OpenPanel(int panelIndex)
    {
        // N?u có panel ?ang m?, ?óng nó l?i
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        // M? panel m?i và ??t nó là panel ?ang ho?t ??ng
        activePanel = menuPanels[panelIndex];
        activePanel.SetActive(true);
    }
    private void OnButtonClick(Button button)
    {
        // ??i màu cho button ???c ch?n
        if (selectedButton != null)
        {
            SetButtonColor(selectedButton, deselectedColor);
            SetChildImageColor(selectedButton, deselectedColorImage); // Reset màu cho Image con
        }

        selectedButton = button;
        SetButtonColor(selectedButton, selectedColor);
        SetChildImageColor(selectedButton, selectedColor); // ??i màu cho Image con
    }

    private void SetButtonColor(Button button, Color color)
    {
        button.GetComponent<Image>().color = color; // Áp d?ng màu m?i cho Image c?a button
    }

    private void SetChildImageColor(Button button, Color color)
    {
        // Tìm ??i t??ng con c?a Button có component Image
        Image childImage = button.transform.GetChild(0).GetComponent<Image>();
        if (childImage != null)
        {
            Debug.Log("Changing color of: " + childImage.gameObject.name); // Ki?m tra xem ?úng ??i t??ng không
            childImage.color = color; // ??i màu c?a Image con
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


