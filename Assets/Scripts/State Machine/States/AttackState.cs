using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override void Enter()
    {
        Debug.Log("Attack");
        character.AttackNeutralFront(); //remove once mid of animation added
        animator.Play(anim.name);
    }
    public override void Do()
    {
        //if(false /*middle of animation*/)
        //character.AttackNeutralFront();
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= anim.length)
            character.isAttackingNeutral = false;
    }
    public override void Exit()
    {
        Debug.Log("attack time: " + animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Debug.Log("attack length: " + anim.length);
        Debug.Log("exit attack state");
        character.isAttackingNeutral = false;
    }
}
