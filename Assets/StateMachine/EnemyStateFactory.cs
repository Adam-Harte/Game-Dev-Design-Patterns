public class EnemyStateFactory
{
    EnemyStateMachine context;

    public EnemyStateFactory(EnemyStateMachine currentContext)
    {
        context = currentContext;
    }
    
    public BaseState EnemyRoaming()
    {
        return new EnemyRoamingState(context, this);
    }

    public BaseState EnemyChase()
    {
        return new EnemyChaseState(context, this);
    }

    public BaseState EnemyAttack()
    {
        return new EnemyAttackState(context, this);
    }
}
