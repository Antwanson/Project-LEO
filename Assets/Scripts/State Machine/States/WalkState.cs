using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override void Enter()
    {
        Debug.Log("Walk");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        if (character.xDir == 0)
            Exit();
    }
    public override void Exit()
    {
        Debug.Log("exit walk state");
    }
}