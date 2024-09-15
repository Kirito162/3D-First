using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject panelSetting;

    public void OnpenSetting()
    {
        panelSetting.SetActive(true);
    }
    public void CloseSetting()
    {
        panelSetting.SetActive(false);
    }

}
