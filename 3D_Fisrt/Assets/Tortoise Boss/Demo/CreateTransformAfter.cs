using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTransformAfter : MonoBehaviour
{
	public Transform particle;
	public float time;
    
	// Use this for initialization

    private void OnEnable()
    {
        Invoke("Create", time);
    }
    void Create()
	{
        Vector3 v = transform.parent.parent.position;
        v.y = 0;
        Singleton.Instance.AudioManager.PlayAtPointSFX(13, transform);
        Destroy(Instantiate(particle, v + transform.forward * 2, transform.rotation).gameObject, 5); 
	}
}
