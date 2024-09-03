using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimationEvents : MonoBehaviour
{
    public SkillSO[] skills;
    public GameObject[] skillObjects;
    public GameObject[] effectObjects;
    public PlayerData playerData;
    public float fireballSpeed;
    public Transform fireballSpawnPoint;

    //Dash
    public float dashDuration = 0.2f; // Th?i gian dash
    public float dashSpeed = 20f; 
    [SerializeField]private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); // L?y CharacterController t? GameObject
    }
    private void ActivateSkillObject(int index, float delay)
    {
        if (index < 0 || index >= skillObjects.Length) return;
        skillObjects[index].SetActive(true);
        StartCoroutine(DeactivateAfterDelay(delay, skillObjects[index]));
    }

    private void ActivateEffectObject(int index, float delay)
    {
        if (index < 0 || index >= effectObjects.Length) return;
        effectObjects[index].SetActive(true);
        StartCoroutine(DeactivateAfterDelay(delay, effectObjects[index]));
    }

    public void Shoot1()
    {
        ActivateSkillObject(0, 0.8f);
        SetDamage(skillObjects[0], skills[0].GetDamage(playerData));
    }

    public void Shield2()
    {
        Singleton.Instance.AudioManager.PlaySFX(7);
        ActivateSkillObject(1, 5);
    }

    public void Combo1()
    {
        ActivateSkillObject(2, 0.5f);
        SetDamage(skillObjects[2], playerData.damage);
        Singleton.Instance.AudioManager.PlaySFX(6);
    }

    public void Combo2()
    {
        ActivateSkillObject(3, 0.5f);
        SetDamage(skillObjects[3], playerData.damage);
        Singleton.Instance.AudioManager.PlaySFX(6);
    }

    public void Combo3()
    {
        ActivateSkillObject(4, 0.5f);
        ActivateEffectObject(0, 0.5f);
        SetDamage(skillObjects[4], playerData.damage);
        Singleton.Instance.AudioManager.PlaySFX(5);
    }

    public void ShootFireball()
    {
        Singleton.Instance.AudioManager.PlaySFX(4);
        GameObject fireball = skillObjects[5];
        fireball.transform.position = fireballSpawnPoint.position;
        fireball.transform.rotation = fireballSpawnPoint.rotation;
        fireball.SetActive(true);
        fireball.GetComponent<Rigidbody>().velocity = fireballSpawnPoint.forward * fireballSpeed;
        SetDamage(fireball, skills[2].GetDamage(playerData));
    }

    private IEnumerator DeactivateAfterDelay(float delay, GameObject gameObject)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    private void SetDamage(GameObject skillObject, int damage)
    {
        DealDamage dealDamageScript = skillObject.GetComponent<DealDamage>();
        if (dealDamageScript != null)
        {
            dealDamageScript.baseDamage = damage;
        }
    }

    //------------------------ Dash -----------------
    public void Dash()
    {
        StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        Vector3 dashDirection = transform.forward;

        while (Time.time < startTime + dashDuration)
        {
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
            yield return null; // Ch? ??n frame ti?p theo
        }
    }
}
