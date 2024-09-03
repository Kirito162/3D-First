using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    public void CastSpell()
    {
        objAttack[0].SetActive(true);
        SetDamage(objAttack[0]);
        StartCoroutine(DeactiveObjAttack(0.1f, objAttack[0]));
    }
    public void Attack1()
    {
        objAttack[1].SetActive(true);
        SetDamage(objAttack[1]);
        StartCoroutine(DeactiveObjAttack(0.1f, objAttack[1]));
    }
}
