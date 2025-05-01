using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorAttackState : State
{
    public bool hasAttacked = false;
    public override void Enter()
    {
        //TODO: Remove this if condition it is not needed
        Debug.Log("Enter Favor Attack");
        if (character.entityFavor.getFavor() >= character.entityFavor.getMaxFavor())  //temp cond
        {
            
            animator.Play(anim.name);
            //double speed
            animator.speed = 2f;
        }
        else
            Debug.Log("Insufficient Favor for Attack, Attack Failed.");
        //locking movement false (means it doesn't retain velocity) Vector2.zero means the velocity of the character is zero durring this attack
        character.lockMovement(false, Vector2.zero);
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
            character.entityFavor.setFavor(0); //remove once mid of animation added
            hasAttacked = true;
            character.AttackFavorFront();
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
        //reset speed
        animator.speed = 1f;
        
        character.unlockMovement();
    }
}
