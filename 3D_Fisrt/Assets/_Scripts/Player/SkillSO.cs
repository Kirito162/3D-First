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

    // Ph??ng th?c ?? tính toán damage có th? ???c override trong các l?p con
    public virtual int GetDamage(PlayerData player)
    {
        return damageSkill + (player.damage); // Ví d? ??n gi?n, có th? thay ??i
    }
}
