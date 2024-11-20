using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
    public override void Enter()
    {
        Debug.Log("Hurt");
        animator.Play(anim.name);
    }
    public override void Do()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("exit hurt state");
    }
}