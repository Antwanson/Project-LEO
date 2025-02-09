using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TauntState : State
{
    public override void Enter()
    {
        Debug.Log("Attack");
        animator.Play(anim.name, 0, 0f);
        character.lockMovement(false, Vector2.zero);
    }
    public override void Do()
    {
        //if(false /*middle of animation*/)
        //character.AttackNeutralFront();
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        
        character.entityFavor.addFavor(.025f);
        
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .55f){

            //logic for if the player is airborne or grounded
            if (character.isGrounded())
            {
                machine.Set(controller.idleState);
                return;
            }
            else
            {
                machine.Set(controller.airState);
                return;
            }
        }
    }
    public override void Exit()
    {
        Debug.Log("exit taunt state");
        character.isTaunting = false;
        character.unlockMovement();
    }
}
