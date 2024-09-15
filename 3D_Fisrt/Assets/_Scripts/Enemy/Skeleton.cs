using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public void Attack()
    {
        objAttack[0].SetActive(true);
        SetDamage(objAttack[0]);
        StartCoroutine(DeactiveObjAttack(0.5f, objAttack[0]));
        Singleton.Instance.AudioManager.PlayAtPointSFX(6, transform);
    }
}
