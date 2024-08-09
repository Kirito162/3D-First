using StarterAssets;
using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu]
public class SlashSkillSO : SkillSO
{
    
    public override void UseSkill(PlayerData player)
    {
        // Ki?m tra ?? mana
        if (player.mana < manaCost)
        {
            Debug.Log("Not enough mana");
            return;
        }

        // Gi?m mana
        player.mana -= manaCost;

        // Tính toán damage
        //damage = GetDamage(player);
        

        // Th?c hi?n hành ??ng c?a skill
        //Debug.Log($"{skillName} used with {damage} damage");


        // Ví d?: T?o m?t ??i t??ng l?a ho?c làm ?i?u gì ?ó v?i damage
    }

}
