using StarterAssets;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public SkillSO[] skills; // Danh sách các k? n?ng
    public Text[] cooldownTexts; // UI Text ?? hi?n th? th?i gian cooldown
    public float[] cooldownTimers; // Th?i gian cooldown còn l?i cho m?i k? n?ng
    public bool[] skillCooldownActive; // Ki?m tra xem k? n?ng có ?ang trong th?i gian cooldown không
    private StarterAssetsInputs _input;
    private Animator _animator;
    public PlayerData playerData;
    private void Start()
    {
        cooldownTimers = new float[skills.Length];
        skillCooldownActive = new bool[skills.Length];
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }

    public void HandleSkills()
    {
        Skill1();
        Skill2();
    }

    private void Skill1()
    {
        if (_input.skill1 && !skillCooldownActive[0] && playerData.mana >= skills[0].manaCost)
        {
            UseSkill(0, playerData);
            _animator.SetTrigger("Skill_1");
            _input.skill1 = false;
        }
    }

    private void Skill2()
    {
        if (_input.skill2)
        {
            UseSkill(1, playerData);
            _animator.SetTrigger("Skill_2");
            _input.skill2 = false;
        }
    }

    public void Shoot1()
    {

        GameObject bullet = Instantiate(skills[0].skillObject[0], transform.position, transform.rotation);
        DealDamage dealdamageScript = bullet.GetComponent<DealDamage>();
        if (dealdamageScript != null)
        {
            dealdamageScript.baseDamage = skills[0].GetDamage(playerData);
        }


    }

    public void Shoot2()
    {
        Instantiate(skills[1].skillObject[0], skills[1].skillPositon.position, transform.rotation);
    }


    public void UseSkill(int skillIndex, PlayerData player)
    {
        if (skillIndex < 0 || skillIndex >= skills.Length)
        {
            Debug.LogError("Invalid skill index");
            return;
        }

        if (skillCooldownActive[skillIndex])
        {
            Debug.Log("Skill is on cooldown");
            return;
        }

        SkillSO skillData = skills[skillIndex];
        if (player.mana < skillData.manaCost)
        {
            Debug.Log("Not enough mana");
            return;
        }

        // Th?c hi?n k? n?ng
        skillData.UseSkill(player);

        // B?t ??u cooldown
        StartCoroutine(CooldownCoroutine(skillIndex, skillData.cooldown));
    }

    private IEnumerator CooldownCoroutine(int skillIndex, float cooldown)
    {
        skillCooldownActive[skillIndex] = true;
        cooldownTimers[skillIndex] = cooldown;

        while (cooldownTimers[skillIndex] > 0)
        {
            cooldownTimers[skillIndex] -= Time.deltaTime;
            UpdateCooldownUI(skillIndex);
            yield return null;
        }

        cooldownTimers[skillIndex] = 0;
        skillCooldownActive[skillIndex] = false;
        UpdateCooldownUI(skillIndex);
    }

    private void UpdateCooldownUI(int skillIndex)
    {
        if (cooldownTexts != null && skillIndex < cooldownTexts.Length)
        {
            cooldownTexts[skillIndex].text = skillCooldownActive[skillIndex]
                ? $"Cooldown: {Mathf.Max(0, cooldownTimers[skillIndex]):F1} s"
                : "Ready!";
        }
    }
}
