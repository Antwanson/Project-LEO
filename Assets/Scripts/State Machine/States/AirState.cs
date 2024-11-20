using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : State
{
    public override void Enter()
    {
        Debug.Log("Falling");
        animator.Play(anim.name);
    }
    public override void Do()
    {

    }
    public override void Exit()
    {

    }
}
