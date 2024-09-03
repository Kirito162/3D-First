using UnityEngine;

[CreateAssetMenu]
public class SkillSO : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public int manaCost;
    public int damageSkill;
    public int requiredLevel;

    //public Transform skillPositon;


    public int GetDamage(PlayerData player)
    {
        return damageSkill + (player.damage); 
    }
}
