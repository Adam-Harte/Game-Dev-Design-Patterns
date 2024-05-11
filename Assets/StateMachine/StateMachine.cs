using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected BaseState currentState;
    public BaseState CurrentState { set => currentState = value; }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        currentState.CheckSwitchStates();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }
}
