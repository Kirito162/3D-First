using StarterAssets;
using System;
using System.Collections;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public SkillSO[] skills; // Danh sách các k? n?ng
    public Text[] cooldownTexts; // UI Text ?? hi?n th? th?i gian cooldown
    public float[] cooldownTimers; // Th?i gian cooldown còn l?i cho m?i k? n?ng
    public Image[] cooldownImages; // Thanh cooldown
    public bool[] skillCooldownActive; // Ki?m tra xem k? n?ng có ?ang trong th?i gian cooldown không

    private StarterAssetsInputs _input;
    private Animator _animator;
    public PlayerData playerData;
    private LevelSystem levelSystem;
    private int _comboStep = 0;
    public float comboMaxDelay = 1f; // Th?i gian t?i ?a gi?a các ?òn ?? ti?p t?c combo
    private Coroutine comboCoroutine;
    public PlayerMana playerMana;

    [SerializeField] Text textPopUp;

    private void Start()
    {
        cooldownTimers = new float[skills.Length];
        skillCooldownActive = new bool[skills.Length];
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
        levelSystem = GetComponent<LevelSystem>();
        playerMana = GetComponent<PlayerMana>();
        //characterController = GetComponent<CharacterController>();
    }

    public void CheckRequireLvSkill(int skillIndex)
    {
        if (skills[skillIndex].requiredLevel > levelSystem.level)
        {
             Singleton.Instance.UIManager.ShowPopup(textPopUp, 2);
        }
    }
    public void HandleSkills()
    {
        Combo();
        CheckSkillInputs();
        //CheckDash();
    }

    private void CheckSkillInputs()
    {
        if (_input.skill1) { ActivateSkill(0); }
        if (_input.skill2) { ActivateSkill(1); }
        if (_input.skill3) { ActivateSkill(2); }
    }

    private void ActivateSkill(int skillIndex)
    {
        //Kiem tra state hien tai, Idle or gan het state thi duoc Use
        if (!IsAnimatorInAllowedState()) return;
        //Kiem tra skill hien tai coldown xong chua
        if (skillCooldownActive[skillIndex]) return;
        SkillSO skillData = skills[skillIndex];
        if (levelSystem.level < skillData.requiredLevel)
        {
            CheckRequireLvSkill(skillIndex);
            textPopUp.text = "Require Level " + skillData.requiredLevel;
            return;
        }
        if (playerMana.mana < skillData.manaCost)
        {
            Singleton.Instance.UIManager.ShowPopup(textPopUp, 2);
            textPopUp.text = "Not enough mana";
            return;
        }
        
        UseSkill(skillIndex);
        
    }

    private void UseSkill(int skillIndex)
    {
        if (skillIndex < 0 || skillIndex >= skills.Length) return;
        _animator.SetTrigger($"Skill_{skillIndex + 1}");
        playerMana.TakeMana(skills[skillIndex].manaCost);

        StartCoroutine(CooldownCoroutine(skillIndex, skills[skillIndex].cooldown));
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
            if (skillCooldownActive[skillIndex])
            {
                cooldownTexts[skillIndex].text = $"{Mathf.Max(0, cooldownTimers[skillIndex]):F1}";
            }
            else
            {
                cooldownTexts[skillIndex].text = ""; // Xóa text khi cooldown k?t thúc
            }
        }

        if (cooldownImages != null && skillIndex < cooldownImages.Length)
        {
            cooldownImages[skillIndex].fillAmount = skillCooldownActive[skillIndex]
                ? (cooldownTimers[skillIndex] / skills[skillIndex].cooldown)
                : 0;
        }
    }

    //--------------- Combo Meele ------------------------
    public void Combo()
    {
        if (!IsAnimatorInAllowedState()) { return; }
        if (_input.combo)
        {
            _input.combo = false;
            
            if (comboCoroutine != null)
            {
                StopCoroutine(comboCoroutine);
            }

            _comboStep++;
            ExecuteCombo();

            // Bat dau lai combo timer
            comboCoroutine = StartCoroutine(ResetComboTimer());
        } 
    }

    private void ExecuteCombo()
    {
        switch (_comboStep)
        {
            case 1:
                _animator.SetTrigger("Attack1");
                break;
            case 2:
                _animator.SetTrigger("Attack2");
                break;
            case 3:
                _animator.SetTrigger("Attack3");
                break;
            default:
                _comboStep = 0; // Reset l?i combo n?u v??t quá s? ?òn cho phép
                break;
        }
    }

    private IEnumerator ResetComboTimer()
    {
        yield return new WaitForSeconds(comboMaxDelay);
        _comboStep = 0; // Reset combo n?u h?t th?i gian
    }

    private bool IsAnimatorInAllowedState()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        // Ki?m tra n?u animator ?ang trong tr?ng thái "Idle" ho?c các tr?ng thái b?n cho phép g?i skill.
        return stateInfo.IsName("Idle Walk Run Blend") || stateInfo.normalizedTime >= 0.9f;
    }
}
