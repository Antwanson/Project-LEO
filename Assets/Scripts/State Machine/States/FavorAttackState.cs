using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorAttackState : State
{
    public override void Enter()
    {
        Debug.Log("Favor Attack");
        if(true /*favor >= maxFavor*/)  //temp cond
        {
            character.AttackNeutralFront();
            //Animator.Play(anim.name);
        }
    }
    public override void Do()
    {
        character.isAttackingFavor = false;
    }
    public override void Exit()
    {
        Debug.Log("exit favor attack state");
        character.isAttackingFavor = false;
    }
}
