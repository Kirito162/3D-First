using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int damage = 20;
    void Start()
    {
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        //Destroy(transform.GetComponent<Rigidbody>());
        if (other.CompareTag("Dragon"))
        {
            Debug.Log("cc1");
            //other.GetComponentInParent<Dragon>().TakeDamage(damage);
            other.GetComponentInParent<Dragon>().TakeDamage(damage);
            //GetComponent<BoxCollider>().enabled = false;

        }
    }
    /*private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        //Destroy(transform.GetComponent<Rigidbody>());
        if (other.CompareTag("Dragon"))
        {
            Debug.Log("cc1");
            //other.GetComponentInParent<Dragon>().TakeDamage(damage);
            other.GetComponent<Dragon>().TakeDamage(damage);

        }
    }*/
}
