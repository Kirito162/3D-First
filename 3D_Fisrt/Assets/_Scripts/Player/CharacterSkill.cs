using StarterAssets;
using UnityEngine;

public class CharacterSkill : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public Transform bulletPoint;

    private StarterAssetsInputs _input;
    private Animator _animator;

    private void Start()
    {
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
        if (_input.skill1)
        {
            _animator.SetTrigger("Skill_1");
            _input.skill1 = false;
        }
    }

    private void Skill2()
    {
        if (_input.skill2)
        {
            _animator.SetTrigger("Skill_2");
            _input.skill2 = false;
        }
    }

    /*public void Shoot1()
    {
        Instantiate(bullet1, bulletPoint.position, transform.rotation);
    }*/

    public void Shoot2()
    {
        Instantiate(bullet2, bulletPoint.position, transform.rotation);
    }
}
