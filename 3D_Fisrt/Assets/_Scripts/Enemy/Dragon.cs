using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public GameObject claw;
    public Transform clawPoint;
    public MeshCollider meshCollider;
    public StateSO state;


    public void Claw()
    {
        //Transform pos = new Vector3(0, 0, animator.transform.position.z);
        GameObject hit = Instantiate(claw, clawPoint.position, transform.rotation);
        DealDamage scriptDealdamage = hit.GetComponent<DealDamage>();
        if (scriptDealdamage != null) 
        {
            scriptDealdamage.baseDamage = state.damage;
        }
    }
    public void Horn()
    {
        //GameObject horn = Instantiate(claw, gameObject.transform.position + new Vector3(0,0,5), transform.rotation);
        meshCollider.isTrigger = !meshCollider.isTrigger;
    }

}
