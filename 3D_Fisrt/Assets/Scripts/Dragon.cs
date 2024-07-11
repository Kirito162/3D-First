using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public GameObject claw;
    public Transform clawPoint;
    public void TakeDamage(int damageAmount)
    {
        Debug.Log("cc2");
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    public void Claw()
    {
        //Transform pos = new Vector3(0, 0, animator.transform.position.z);
        GameObject hit = Instantiate(claw, clawPoint.position, transform.rotation);
    }
}
