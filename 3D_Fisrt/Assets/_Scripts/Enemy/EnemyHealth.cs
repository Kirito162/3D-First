
public class EnemyHealth : Health, IDamageable
{
    public EnemyData enemyState;

    public override void OnEnable()
    {
        hp = enemyState.hp;
        healthBar.maxValue = hp;
        base.OnEnable();
    }


}
