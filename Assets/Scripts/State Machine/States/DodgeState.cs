using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    public override void Enter()
    {
        Debug.Log("Dodge");
        //Animator.Play(anim.name);

        //move character back or make immune from hit idk
    }
    public override void Do()
    {

    }
    public override void Exit()
    {
        Debug.Log("exit dodge state");
    }
}
