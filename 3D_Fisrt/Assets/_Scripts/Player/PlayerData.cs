
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : StateSO
{
    public int defautlHp;
    public int defautlDamage;
/*    public string playerName;
    public int hp;*/
    public int mana;
    //public int damage;
    public Vector3 currentPosition;

/*    public int Damage => damage;
    public int HP => hp;*/


    public void ResetData()
    {
        hp = defautlHp;
        damage = defautlDamage;
        currentPosition = new Vector3(0,0,0) ;
    }
}
