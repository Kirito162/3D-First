using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    public Transform transCam;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transCam);
    }
}
