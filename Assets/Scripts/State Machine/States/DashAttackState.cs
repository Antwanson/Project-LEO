using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackState : State
{
    public bool hasAttacked = false;
    public override void Enter()
    {
        Debug.Log("Dash Attack");
        animator.Play(anim.name, 0, 0.05f);
        animator.speed = 1.5f;

        //play animation in reverse

        character.lockMovement(false, new Vector2(character.attackDir * 10, 0));
    }
    public override void Do()
    {

        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (hasAttacked == false && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .5f)
        {
            character.AttackDash();
            hasAttacked = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .6f)
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
