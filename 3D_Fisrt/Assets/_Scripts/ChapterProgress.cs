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
    [SerializeField] private string previousChapterKey; // Nh?p key (tên c?a chapter tr??c ?ó) trong Inspector
    [SerializeField] private string currentChapterKey; // Nh?p key (tên c?a chapter tr??c ?ó) trong Inspector


    void Start()
    {
        // Load s? sao c?a chapter tr??c ?ó
        int previousChapterStars = PlayerPrefs.GetInt(previousChapterKey, 0);
        int currentChapterStars = PlayerPrefs.GetInt(currentChapterKey, 0);
        Debug.Log(previousChapterKey + " da dat duoc " + previousChapterStars + " sao!");
        // Ki?m tra xem chapter tr??c có ??t ???c 3 sao hay ch?a
        if (currentChapterKey != "Chapter1")
        {
            if (previousChapterStars == 3)
            {
                playButton.SetActive(true);
                imgLockButton.SetActive(false);
                //playButton.interactable = true; // M? khóa nút Play
            }
            else
            {
                playButton.SetActive(false);
                //playButton.interactable = false; // Khóa nút Play
            }
        }
        
        for (int i = 0; i < currentChapterStars; i++)
        {
            starImages[i].GetComponent<Image>().color = Color.white;
        }
    }
}
