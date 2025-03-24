using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public bool hasDodged = false;
    public override void Enter()
    {
        Debug.Log("Dodge");
        animator.Play(anim.name);
        animator.speed = 0.5f;

        //move character back or make immune from hit idk
        character.EnableImmunity();
    }
    public override void Do()
    {
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (hasDodged == false && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length*4)
        {
            //character.disableHitbox
            hasDodged = true;
        }

        if (hasDodged)
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

        animator.speed = 1.0f;
        hasDodged = false;
        character.DisableImmunity();
    }
}
