using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpState : IState
{
    public FSM machine;
    public float timer = 0f;

    public void Enter(FSM machine) {
        this.machine = machine;

        // activate stand up animation
        this.machine.animator.SetTrigger("standUp");
    }

    public void Execute() {
        Debug.Log("StandUp");
        
        timer += Time.deltaTime;

        if(timer >= this.machine.animator.GetCurrentAnimatorStateInfo(0).length) {
            machine.ChangeState(new IdleState());
        }
    }

    public void Exit() {
        machine.agent.isStopped = false;
    }
}
