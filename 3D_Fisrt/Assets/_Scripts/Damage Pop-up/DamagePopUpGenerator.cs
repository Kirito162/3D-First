using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopUpGenerator : MonoBehaviour
{
    //public static DamagePopUpGenerator Instance;
    public GameObject prefab;
    /*void Awake()
    {
        Instance = this;
    }*/

    public void CreatePopup(Vector3 position, string text, Color color)
    {
        Vector3 randomness = new Vector3(Random.Range(0, 1.25f), Random.Range(0, 1.25f), Random.Range(0, 1.25f));
        var popup = Instantiate(prefab, position + randomness, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;
        temp.faceColor = color;

        Destroy(popup, 1f);
    }
}
