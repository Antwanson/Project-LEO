using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorAttackState : State
{
    public bool hasAttacked = false;
    public override void Enter()
    {
        Debug.Log("Enter Favor Attack");
        if (character.entityFavor.getFavor() >= character.entityFavor.getMaxFavor())  //temp cond
        {
            
            animator.Play(anim.name);
        }
        else
            Debug.Log("Insufficient Favor for Attack, Attack Failed.");
    }
    public override void Do()
    {
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (hasAttacked == false && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .55f)
        {
            character.AttackFavorFront();
            character.entityFavor.setFavor(0); //remove once mid of animation added
            hasAttacked = true;
        }

        //TODO: fix original animation so this check is not needed and can instead use animationComplete()
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .75f){
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
        Debug.Log("exit favor attack state");
        hasAttacked = false;
        character.isAttackingFavor = false;
    }
}
