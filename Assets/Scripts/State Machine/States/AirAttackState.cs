using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAttackState : State
{
    public bool hasAttacked = false;
    public AudioClip attackSound;
    public AudioSource audioSource;
    public override void Enter()
    {
        Debug.Log("Air Attack");
        animator.Play(anim.name, 0, .2f);
        animator.speed = 2.3f;
        //set gravity to .1 of the normal gravity
        //set y velocity to 0
        character.rb.velocity = new Vector2(character.rb.velocity.x, character.rb.velocity.y * 0.1f);
        character.rb.gravityScale = 0.1f * 6f;
        //character.lockMovement(false, new Vector2(0, -100));
        //play sound
        if (attackSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackSound);
        }
    }
    public override void Do()
    {

        if (health.currentHealth <= 0)
        {
            machine.Set(controller.deadState);
            return;
        }

        if (hasAttacked == false && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .35f)
        {
            character.AttackAir();
            hasAttacked = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length * .70f)
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
        Debug.Log("exit air attack state");
        hasAttacked = false;
        character.isAttackingNeutral = false;
        //stop sound
        if (audioSource != null && attackSound != null)
        {
            audioSource.Stop();
        }
        //reset gravity to normal
        character.rb.gravityScale = 6f;
        //reset the animation speed
        animator.speed = 1f;
        character.unlockMovement();
    }
}
