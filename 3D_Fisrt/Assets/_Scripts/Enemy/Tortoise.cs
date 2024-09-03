using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : Enemy
{
/*    public Transform[] positions;

    public List<Particles> particles = new List<Particles>();*/
    
    public void Attack1()
    {
        Singleton.Instance.AudioManager.PlayAtPointSFX(8, transform);
        objAttack[0].SetActive(true);
        SetDamage(objAttack[0]);
        StartCoroutine(DeactiveObjAttack(2f, objAttack[0]));
    }
    public void Attack2()
    {
        Singleton.Instance.AudioManager.PlayAtPointSFX(9, transform);
        objAttack[1].SetActive(true);
        SetDamage(objAttack[1]);
        StartCoroutine(DeactiveObjAttack(2f, objAttack[1]));
    }
    public void Attack3()
    {
        Singleton.Instance.AudioManager.PlayAtPointSFX(10, transform);
        objAttack[2].SetActive(true);
        SetDamage(objAttack[2]);
        StartCoroutine(DeactiveObjAttack(2f, objAttack[2]));
    }
    public void SoundDeath()
    {
        Singleton.Instance.AudioManager.PlayAtPointSFX(11, transform);
    }
}
