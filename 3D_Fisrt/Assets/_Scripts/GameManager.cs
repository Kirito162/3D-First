using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;

    public void OnGameOver() 
    {
        panelGameOver.SetActive(true);
    }
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
}
