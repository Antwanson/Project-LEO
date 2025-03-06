using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    public bool hasDashed = false;
    public override void Enter()
    {
        Debug.Log("Dash");
        animator.Play(anim.name, 0, 0f);
        animator.speed = 8f; // remove once actual anim input
        character.isDashing = true;

        //locking movement IF pushing player, delete if just increasing velocity
        //character.lockMovement(false, Vector2.zero);
        character.EnableImmunity();
    }
    public override void Do()
    {
        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (!hasDashed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .5f)//change to .9f after anim input
        {
            Debug.Log("Dashing");
            character.DashForward();
            hasDashed = true;
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
        Debug.Log("exit dash state");
        character.isDashing = false;

        hasDashed = false;
        animator.speed = 1f;
        character.unlockMovement();
        character.DisableImmunity();
    }
}