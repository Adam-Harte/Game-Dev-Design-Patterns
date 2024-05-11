using UnityEngine;

public abstract class BaseState
{
    private StateMachine context;
    public BaseState(StateMachine currentContext)
    {
        context = currentContext;
    }
    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void FixedUpdateState();

    public abstract void ExitState();

    public abstract void CheckSwitchStates();

    protected void SwitchState(BaseState newState)
    {
        ExitState();

        newState.EnterState();

        context.CurrentState = newState;
    }
}
