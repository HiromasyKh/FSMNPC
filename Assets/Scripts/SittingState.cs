using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingState : IState
{
    public FSM machine;
    private float timer = 0f;

    public void Enter(FSM machine) {
        this.machine = machine;

        // activate sitting animation
        this.machine.animator.SetTrigger("sitDown");

        this.machine.agent.isStopped = true; // stop the character from moving when in the idle state
    }

    public void Execute() {
        Debug.Log("Sitting");

        timer += Time.deltaTime;

        if(timer >= 10) {
            machine.health = 100f;
            machine.ChangeState(new StandUpState());
        }     
    }

    public void Exit() {
        machine.agent.isStopped = false;
    }
}