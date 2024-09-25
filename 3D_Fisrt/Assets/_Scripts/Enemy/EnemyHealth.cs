using System.Collections;
using UnityEngine;

public class EnemyHealth : Health, IDamageable
{
    public EnemyData enemyState;
    private Transform transCam;
    private bool isHealthBarVisible = false;

    public override void OnEnable()
    {
        // L?y camera có tag là "MainCamera"
        transCam = Camera.main.transform;

        hp = enemyState.hp;
        healthBar.gameObject.SetActive(false);
        textHp.gameObject.SetActive(false);
        base.OnEnable();
    }

    public override void TakeDamage(int damageAmount, bool isSkillDamage = false)
    {
        if (!isHealthBarVisible)
        {
            healthBar.gameObject.SetActive(true);
            textHp.gameObject.SetActive(true);
            isHealthBarVisible = true;
        }

        //StopCoroutine(HideHealthBarAfterDelay());
        //StartCoroutine(HideHealthBarAfterDelay());
        CancelInvoke("HideHealthBarAfterDelay");
        Invoke("HideHealthBarAfterDelay", 10f);
        base.TakeDamage(damageAmount, isSkillDamage);
        Singleton.Instance.DamagePopUpGenerator.CreatePopup(transform.position + new Vector3(0,2,0), damageAmount.ToString(), Color.red);
    }

    private void HideHealthBarAfterDelay()
    {
        //yield return new WaitForSeconds(10f);
        healthBar.gameObject.SetActive(false);
        textHp.gameObject.SetActive(false);
        isHealthBarVisible = false;
    }

    private void LateUpdate()
    {
        if (isHealthBarVisible)
        {
            LookAtCamera();
        }
    }

    private void LookAtCamera()
    {
        Vector3 direction = transCam.position - transform.position;
        healthBar.transform.parent.rotation = Quaternion.LookRotation(direction);
    }
}
