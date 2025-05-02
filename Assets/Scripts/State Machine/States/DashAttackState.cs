using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackState : State
{
    public bool hasAttacked = false;
    public override void Enter()
    {
        Debug.Log("Dash Attack");
        animator.Play(anim.name, 0, .2f);
        animator.speed = 6f;

        //character.lockMovement(false, new Vector2(0, -100));
        character.lockMovement(false, new Vector2(character.attackDir * 15, 0));
    }
    public override void Do()
    {

        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (hasAttacked == false && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .9f)
        {
            character.AttackDash();
            hasAttacked = true;
        }

        if (animationComplete())
        {

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
        Debug.Log("attack time: " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Debug.Log("attack length: " + anim.length);
        Debug.Log("exit dash attack state");
        hasAttacked = false;
        character.isAttackingNeutral = false;

        //reset the animation speed
        animator.speed = 1f;
        character.unlockMovement();
    }
}
