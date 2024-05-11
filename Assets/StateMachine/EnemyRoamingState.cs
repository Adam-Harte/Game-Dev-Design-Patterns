using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoamingState : BaseState
{
    private EnemyStateMachine context;
    private EnemyStateFactory enemyStatefactory;
    private Vector3 roamPosition;

    public EnemyRoamingState(EnemyStateMachine currentContext, EnemyStateFactory factory) : base(currentContext)
    {
        context = currentContext;
        enemyStatefactory = factory;
    }

    public Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    public Vector3 GetRoamingPosition()
    {
        return context.transform.position + GetRandomDir() * Random.Range(10f, 50f);
    }
    public override void EnterState() {
        roamPosition = GetRoamingPosition();
    }

    public override void UpdateState() {
        Debug.Log("Roaming!");
        float step = 1f * Time.deltaTime;
        context.transform.position = Vector3.MoveTowards(context.transform.position, roamPosition, step);

        if (Vector3.Distance(context.transform.position, roamPosition) < 10f)
        {
            roamPosition = GetRoamingPosition();
        }
    }

    public override void FixedUpdateState() {
    }

    public override void ExitState() {

    }

    public override void CheckSwitchStates()
    {
        if (Vector3.Distance(context.transform.position, context.Player.transform.position) < 10f)
        {
            SwitchState(enemyStatefactory.EnemyChase());
        }
    }
}
