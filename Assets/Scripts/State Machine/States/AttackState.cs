using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Enter()
    {
        Debug.Log("Attack");
        character.AttackNeutralFront(); //remove once mid of animation added
        //Animator.Play(anim.name);
    }
    public override void Do()
    {
        //if(false /*middle of animation*/)
            //character.AttackNeutralFront();
        if (true/*animation ends*/)
            character.isAttackingNeutral = false;
    }
    public override void Exit()
    {
        Debug.Log("exit attack state");
        character.isAttackingNeutral = false;
    }
}
