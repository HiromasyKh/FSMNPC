using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when inheriting from IState interface, you will get errors because you have to implement the 3 methods in IState interface
public class IdleState : IState
{
    public FSM machine;
    private float timer = 0f;

    public void Enter(FSM machine) {
        this.machine = machine;

        // access the idle animation so that when the character enters idle state, the animation also starts as well
        this.machine.animator.SetBool("isIdle", true);
        this.machine.animator.SetBool("isWalking", false);
        this.machine.agent.isStopped = true; // stop the character from moving when in the idle state
    }

    public void Execute() {
        timer += Time.deltaTime;

        if(timer >= 10) {
            machine.ChangeState(new PatrolState());
        }
        Debug.Log("Idle");
    }

    public void Exit() {
        machine.agent.isStopped = false;
    }
}
