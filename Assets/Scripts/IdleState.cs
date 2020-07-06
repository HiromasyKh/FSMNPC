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

        // activate idle animation
        this.machine.animator.SetBool("isIdle", true);
        this.machine.animator.SetBool("isWalking", false);
        
        this.machine.agent.isStopped = true; // stop the character from moving when in the idle state
    }

    public void Execute() {
        Debug.Log("Idle");
        machine.health -= 2 * Time.deltaTime;

        timer += Time.deltaTime;

        if(timer >= 10) {
            machine.ChangeState(new PatrolState());
        }
        
        if(machine.health < 10) {
            machine.ChangeState(new GoPutHealthState());
        }
    }

    public void Exit() {
        machine.agent.isStopped = false;
    }
}
