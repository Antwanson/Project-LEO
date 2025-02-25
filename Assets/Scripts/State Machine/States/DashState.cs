using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    public bool hasDashed = false;
    public override void Enter()
    {
        Debug.Log("Dash");
        character.dashSpeed = 2;
        //Animator.Play(anim.name);

        //locking movement IF pushing player, delete if just increasing velocity
        character.lockMovement(false, Vector2.zero);
    }
    public override void Do()
    {
        //if (true/*animation completed*/)
        //    character.isDashing = false;

        //add logic eventually for state transition

        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (!hasDashed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .9f)
        {
            Debug.Log("Dashing");
            //character.dashForward(); //or smth
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
        character.dashSpeed = 1;

        hasDashed = false;
        character.unlockMovement();
    }
}