using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    private EnemyStateFactory states;
    private GameObject player;
    private Renderer color;

    public GameObject Player { get => player; }
    public Renderer Color { get => color; }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        color = GetComponent<Renderer>();
        states = new EnemyStateFactory(this);
        currentState = states.EnemyRoaming();
        currentState.EnterState();
    }
}
