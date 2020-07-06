using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPutHealthState : IState
{
    public FSM machine;

    public Transform nearestChair;

    public void Enter(FSM machine) {
        this.machine = machine;

        // activate the patrol animation as it go to put the health back
        this.machine.animator.SetBool("isIdle", false);
        this.machine.animator.SetBool("isWalking", true);

        // searching for the closest bench
        float minDistance =  1000f;

        foreach(Transform chair in machine.chairs) {
            if(Vector3.Distance(machine.transform.position, chair.position) < minDistance){
                minDistance = Vector3.Distance(machine.transform.position, chair.position);
                nearestChair = chair;
            }
        }
    }

    public void Execute() {
        Debug.Log("GoPutHealth");
        
        machine.agent.SetDestination(nearestChair.position);

        // if the character reaches the chair then let character sitting down on the chair
        if (machine.agent.remainingDistance <= machine.agent.stoppingDistance) {
            machine.ChangeState(new SittingState());
        }
    }

    public void Exit() {
        machine.agent.isStopped = false;
    }
}
