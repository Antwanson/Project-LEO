using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override void Enter()
    {
        Debug.Log("Walk");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        //death is first obviously
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }
        //if player is airborne return to air state
        if (!character.isGrounded())
        {
            machine.Set(controller.airState);
            return;
        }
        //if the player is attacking switch to attack state
        if (character.isAttackingNeutral)
        {
            machine.Set(controller.attackState);
            return;
        }
        //if the player is attacking with favor switch to favor attack state
        if (character.isAttackingFavor)
        {
            machine.Set(controller.favorAttackState);
            return;
        }
        //return to idle state if not moving
        if (character.xDir == 0) {
            machine.Set(controller.idleState);
            return;
        }
    }
    public override void Exit()
    {
        Debug.Log("exit walk state");
    }
}