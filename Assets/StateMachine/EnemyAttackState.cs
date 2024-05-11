using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    private EnemyStateMachine context;
    private EnemyStateFactory enemyStatefactory;

    public EnemyAttackState(EnemyStateMachine currentContext, EnemyStateFactory factory) : base(currentContext)
    {
        context = currentContext;
        enemyStatefactory = factory;
    }

    public override void EnterState()
    {
        context.Color.material.SetColor("Red", Color.red);
    }

    public override void UpdateState()
    {
        Debug.Log("Attacking!");
    }

    public override void FixedUpdateState()
    {
    }

    public override void ExitState()
    {
        context.Color.material.SetColor("Blue", Color.blue);
    }

    public override void CheckSwitchStates()
    {
        if (Vector3.Distance(context.transform.position, context.Player.transform.position) > 10f)
        {
            SwitchState(enemyStatefactory.EnemyChase());
        }
    }
}
