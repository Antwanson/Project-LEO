using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        Debug.Log("Idle");
        animator.Play(anim.name);
    }
    public override void Do()
    {/*
        if (!character.isGrounded() || character.xDir != 0)
            isComplete = true;*/
    }
    public override void Exit()
    {

    }
}
