using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : Enemy
{
    public void BasicAttack()
    {
        objAttack[0].SetActive(true);
        SetDamage(objAttack[0]);
        StartCoroutine(DeactiveObjAttack(0.1f, objAttack[0]));
    }
    public void ClawAttack()
    {
        objAttack[1].SetActive(true);
        SetDamage(objAttack[1]);
        StartCoroutine(DeactiveObjAttack(0.1f, objAttack[1]));
    }
    public void HornAttack()
    {
        objAttack[2].SetActive(true);
        SetDamage(objAttack[2]);
        StartCoroutine(DeactiveObjAttack(0.1f, objAttack[2]));
    }

    

}
