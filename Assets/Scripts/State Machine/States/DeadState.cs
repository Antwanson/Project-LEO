using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override void Enter()
    {
        Debug.Log("Dead");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        //when the animation is complete call kill
        //TODO: please fix animation so it ends at the proper time so we can use animationComplete() instead
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length*.63f)
        {
            character.kill();
            return;
        }
    }
    public override void Exit()
    {
        Debug.Log("exit dead state");
    }
}