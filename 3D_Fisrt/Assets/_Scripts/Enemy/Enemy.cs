using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public List<GameObject> objAttack;
    //public Transform hitPos;
    public StateSO state;
    public List<GameObject> itemsSpawn;
    public int maxCountSpawnRandom = 3;
    // Start is called before the first frame update
    public virtual void SpawnItemOnDeath()
    {
        int countSpawn = Random.Range(0, maxCountSpawnRandom);
        for (int i = 0; i < countSpawn; i++)
        {
            int itemRandom = Random.Range(0, itemsSpawn.Count -1);
            Instantiate(itemsSpawn[itemRandom], transform.position + new Vector3(Random.Range(0,2), Random.Range(1f, 3f), Random.Range(0, 2)),
                transform.rotation*Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        }
        
    }
    
    public virtual void SetDamage(GameObject objAttack)
    {
        //GameObject bullet = Instantiate(hitAttack, hitPos.position, transform.rotation);
        //objAttack.SetActive(true);
        DealDamage dealdamageScript = objAttack.GetComponent<DealDamage>();
        if (dealdamageScript != null)
        {
            dealdamageScript.baseDamage = state.damage;
        }
    }
/*    public void DeactiveObjAttack(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }*/



    public virtual IEnumerator DeactiveObjAttack(float delay, GameObject gameObject)
    {
        // ??i th?i gian ch? ??nh
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject, 2f);
    }

}
