using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterProgress : MonoBehaviour
{
    /*    [Header("Star Requirements for Current Chapter")]
        [SerializeField] private bool condition1Met;
        [SerializeField] private bool condition2Met;
        [SerializeField] private bool condition3Met;*/
    //[SerializeField] private Button playButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject imgLockButton;
    [SerializeField] private List<GameObject> starImages = new List<GameObject>();

    [Header("Previous Chapter Key")]
    [SerializeField] private string previousChapterKey; // Nh?p key (t�n c?a chapter tr??c ?�) trong Inspector
    [SerializeField] private string currentChapterKey; // Nh?p key (t�n c?a chapter tr??c ?�) trong Inspector


    void Start()
    {
        // Load s? sao c?a chapter tr??c ?�
        int previousChapterStars = PlayerPrefs.GetInt(previousChapterKey, 0);
        int currentChapterStars = PlayerPrefs.GetInt(currentChapterKey, 0);
        Debug.Log(previousChapterKey + " da dat duoc " + previousChapterStars + " sao!");
        // Ki?m tra xem chapter tr??c c� ??t ???c 3 sao hay ch?a
        if (currentChapterKey != "Chapter1")
        {
            if (previousChapterStars == 3)
            {
                playButton.SetActive(true);
                imgLockButton.SetActive(false);
                //playButton.interactable = true; // M? kh�a n�t Play
            }
            else
            {
                playButton.SetActive(false);
                //playButton.interactable = false; // Kh�a n�t Play
            }
        }
        
        for (int i = 0; i < currentChapterStars; i++)
        {
            starImages[i].GetComponent<Image>().color = Color.white;
        }
    }
}
