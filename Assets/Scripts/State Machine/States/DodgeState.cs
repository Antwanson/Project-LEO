using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public bool hasDodged = false;
    public override void Enter()
    {
        Debug.Log("Dodge");
        //Animator.Play(anim.name);

        //move character back or make immune from hit idk
    }
    public override void Do()
    {
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (hasDodged == false && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .9f)
        {
            //character.disableHitbox
            hasDodged = true;
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
        Debug.Log("exit dodge state");

        hasDodged = false;
        //character.enableHitbox
    }
}
