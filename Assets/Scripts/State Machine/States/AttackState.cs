using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Enter()
    {
        Debug.Log("Attack");
        character.AttackNeutralFront();
        //Animator.Play(anim.name);
    }
    public override void Do()
    {
        character.isAttackingNeutral = false;
    }
    public override void Exit()
    {
        Debug.Log("exit attack state");
        character.isAttackingNeutral = false;
    }
}
