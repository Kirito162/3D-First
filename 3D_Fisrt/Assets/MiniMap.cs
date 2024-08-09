using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject miniMapMin;
    public GameObject miniMapMax;

    public void ChangeMiniMap()
    {
        if (miniMapMin.activeSelf)
        {
            miniMapMin.SetActive(false);
            miniMapMax.SetActive(true);
        }
        else
        {
            miniMapMin.SetActive(true);
            miniMapMax.SetActive(false);
        }
        
    }
}
