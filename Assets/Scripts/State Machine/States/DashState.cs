using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    public bool hasDashed = false;
    public AudioClip dashSound;
    public AudioSource audioSource;
    
    public override void Enter()
    {
        
        StartCoroutine(character.DashCooldown(0.7f));

        Debug.Log("Dash");
        animator.Play(anim.name, 0, 0f);
        animator.speed = 3f; // remove once actual anim input
        character.isDashing = true;
        //play dash sound set volume to 0.5f

        audioSource.volume = 0.5f;
        if (dashSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(dashSound);
        }

        //locking movement IF pushing player, delete if just increasing velocity
        //character.lockMovement(false, Vector2.zero);
        character.EnableImmunity();

        character.lockMovement(false, new Vector2(character.attackDir * 22, 0));
    
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
            //character.DashForward();
            hasDashed = true;
        }

        if(character.isAttackingNeutral)
            machine.Set(controller.dashAttackState);

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

        //stop the dash sound
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.volume = 1f;
        hasDashed = false;
        animator.speed = 1f;
        character.unlockMovement();
        character.DisableImmunity();
    }
}