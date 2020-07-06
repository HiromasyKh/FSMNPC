﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FSM : MonoBehaviour
{
    // By default, the character is in IdleState
    public IState currentState;

    // variable for keep track on animator
    public Animator animator;

    // NavMeshAgent help character to avoid collide into each other while moving to their goal
    public NavMeshAgent agent;

    // wayPoints which is th goal location for the character to go
    public Transform[] wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Execute();
    }

    // function for changing the current state to the next state
    public void ChangeState(IState newState) {
        // check if we have the current state
        if (currentState != null) {
            currentState.Exit();
        }

        // assign the newState into currentState
        currentState = newState;
        // enter the state
        currentState.Enter(this); // this refers to FSM 
    }
}
