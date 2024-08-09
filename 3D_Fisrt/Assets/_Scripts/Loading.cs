using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Text loadingText;
    private int dotCount =3;
    void Start()
    {
        //Invoke("LoadScene", 2f);
        InvokeRepeating("ChangeText", .25f, .25f);
        StartCoroutine(LoadSceneAsynce());
    }

    void ChangeText()
    {
        dotCount--;
        if (dotCount <= 0) { dotCount = 3; }
        loadingText.text = "Loading \n";
        for (int i = 0; i < dotCount; i++) 
        {
            loadingText.text += ".";
        }
    }
    IEnumerator LoadSceneAsynce()   
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation async = SceneManager.LoadSceneAsync("Survival", LoadSceneMode.Additive);
        while (!async.isDone) { yield return null; }

        Scene scene = SceneManager.GetSceneByName("Survival");
        if (scene != null && scene.isLoaded) 
        {
            gameObject.SetActive(false);
            SceneManager.SetActiveScene(scene);
        }

    }

    /*void LoadScene()
    {
        SceneManager.LoadScene("Survival");
    }*/
}
