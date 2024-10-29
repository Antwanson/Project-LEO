using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Enter()
    {
        Debug.Log("Attack");
        //Animator.Play(anim.name);
    }
    public override void Do()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("exit attack state");
    }
}
