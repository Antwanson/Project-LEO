using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        Debug.Log("Idle");
        animator.Play(anim.name);

        //fixes issue on player attack might cause other issues :p
        character.isAttackingFavor = false;
        character.isAttackingNeutral = false;
        character.isTaunting = false;
    }
    public override void Do()
    {
        //probably the hardest one to do

        //death is first obviously
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }
        //if the player is moving switch to walk state
        if (!(character.xDir == 0))
        {
            machine.Set(controller.walkState);
            return;
        }
        //if the player is attacking switch to attack state
        if (character.isAttackingNeutral)
        {
            machine.Set(controller.attackState);
            return;
        }
        //if the player is attacking with favor switch to favor attack state
        if (character.isAttackingFavor && character.entityFavor.getFavor() >= character.entityFavor.getMaxFavor())
        {
            machine.Set(controller.favorAttackState);
            return;
        }
        //if taunting switch to taunt state
        if (character.isTaunting)
        {
            machine.Set(controller.tauntState);
            return;
        }
        //if the player is not grounded then switch to air state
        if (!character.isGrounded())
        {
            machine.Set(controller.airState);
            return;
        }

    }
    public override void Exit()
    {

    }
}
