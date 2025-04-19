using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : State
{
    public override void Enter()
    {
        Debug.Log("Falling");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        //contains logic for which states to transition to out of the air state

        //Death state first because it is the most important
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }
        //walking state if grounded and moving
        if (character.isGrounded() && character.xDir == 0)
        {
            machine.Set(controller.walkState);
            return;
        }
        //if the player is grounded return to idle state
        if (character.isGrounded())
        {
            machine.Set(controller.idleState);
            return;
        }
        if (character.isAttackingNeutral)
        {
            Debug.Log("reached if attacking");
            machine.Set(controller.airAttackState);
            return;
        }

    }
    public override void Exit()
    {

    }
}
