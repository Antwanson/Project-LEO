using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public override void Enter()
    {
        Debug.Log("Jump");
        animator.Play(anim.name);
    }
    public override void Do()
    {
    }
    public override void Exit()
    {
        Debug.Log("exit jump state");
    }
}
