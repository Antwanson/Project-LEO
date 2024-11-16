using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : State
{
    public override void Enter()
    {
        Debug.Log("Dash");
        character.dashSpeed = 2;
        //Animator.Play(anim.name);
    }
    public override void Do()
    {
        if (true/*animation completed*/)
            character.isDashing = false;
    }
    public override void Exit()
    {
        Debug.Log("exit dash state");
        character.dashSpeed = 1;
    }
}