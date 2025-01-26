using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Enter()
    {
        Debug.Log("Attack");
        animator.Play(anim.name);
        
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

        if (animationComplete()){

            character.AttackNeutralFront(); //remove once mid of animation added
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
        Debug.Log("exit attack state");
        character.isAttackingNeutral = false;
    }
}
