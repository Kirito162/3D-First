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

        // T�nh to�n damage
        //damage = GetDamage(player);
        

        // Th?c hi?n h�nh ??ng c?a skill
        //Debug.Log($"{skillName} used with {damage} damage");


        // V� d?: T?o m?t ??i t??ng l?a ho?c l�m ?i?u g� ?� v?i damage
    }

}
