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
        if (animationComplete())
            animComplete = true;
    }
    public override void Exit()
    {
        Debug.Log("exit dead state");
    }
}