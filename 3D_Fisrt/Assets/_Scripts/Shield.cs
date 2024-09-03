using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private PlayerHealth health;
    public float timeShield =5f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        health = GetComponentInParent<PlayerHealth>();
        health.isShield = true;
        Invoke("Deactivate", timeShield);
        //stroy(gameObject, timeShield);

    }

    private void OnDisable()
    {
        health.isShield = false;
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
