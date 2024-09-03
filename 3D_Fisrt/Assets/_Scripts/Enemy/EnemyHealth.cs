
public class EnemyHealth : Health, IDamageable
{
    public EnemyData enemyState;

    public override void OnEnable()
    {
        hp = enemyState.hp;
        
        base.OnEnable();
    }
}
