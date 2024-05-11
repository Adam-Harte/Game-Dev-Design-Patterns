using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : BaseState
{
    private EnemyStateMachine context;
    private EnemyStateFactory enemyStatefactory;

    public EnemyChaseState(EnemyStateMachine currentContext, EnemyStateFactory factory) : base(currentContext)
    {
        context = currentContext;
        enemyStatefactory = factory;
    }

    public override void EnterState()
    {
        
    }

    public override void UpdateState()
    {
        Debug.Log("Chasing!");
        float step = 1f * Time.deltaTime;
        context.transform.position = Vector3.MoveTowards(context.transform.position, context.Player.transform.position, step);
    }

    public override void FixedUpdateState()
    {
    }

    public override void ExitState()
    {

    }

    public override void CheckSwitchStates()
    {
        if (Vector3.Distance(context.transform.position, context.Player.transform.position) < 5f)
        {
            SwitchState(enemyStatefactory.EnemyAttack());
        }

        if (Vector3.Distance(context.transform.position, context.Player.transform.position) > 30f)
        {
            SwitchState(enemyStatefactory.EnemyRoaming());
        }
    }
}
