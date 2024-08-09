using UnityEngine;

public abstract class SkillSO : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public int manaCost;
    public int damageSkill;
    public GameObject[] skillObject;
    public Transform skillPositon;
    // Ph??ng th?c tr?u t??ng ?? th?c hi?n k? n?ng
    public abstract void UseSkill(PlayerData player);

    // Ph??ng th?c ?? t�nh to�n damage c� th? ???c override trong c�c l?p con
    public virtual int GetDamage(PlayerData player)
    {
        return damageSkill + (player.damage); // V� d? ??n gi?n, c� th? thay ??i
    }
}
