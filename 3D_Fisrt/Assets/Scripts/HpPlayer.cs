using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int hpPlayer =100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitDragon")
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        hpPlayer -= damageAmount;
        //PLay anim get hit player
        /*if (hpPlayer <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<MeshCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }*/
    }
}
