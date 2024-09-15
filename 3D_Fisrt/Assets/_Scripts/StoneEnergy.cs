using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneEnergy : Enemy
{
    private void Start()
    {
        SpawnRandomItem();
    }
    public void SpawnRandomItem()
    {
        InvokeRepeating("SpawnItemOnDeath", 10, 15);
    }
    public void SpawnRandomBuff()
    {
        //int countSpawn = Random.Range(0, objAttack.Count-1);
        for (int i = 0; i < objAttack.Count - 1; i++)
        {
            objAttack[i].SetActive(false);
            
        }
        int buffRandom = Random.Range(0, objAttack.Count - 1);
        objAttack[buffRandom].SetActive(true);
        //Instantiate(objAttack[buffRandom], transform.position, transform.rotation);
    }
    public override void DestroyEnemy()
    {
        Destroy(gameObject, 1.5f);
    }
}
