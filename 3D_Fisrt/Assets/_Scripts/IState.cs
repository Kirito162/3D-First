/*public interface IState
{
    int Damage { get; }
    int HP { get; }
}*/

using UnityEngine;

public abstract class StateSO : ScriptableObject
{
    public string nameCharacter;
    public int hp;
    public int damage;

}
