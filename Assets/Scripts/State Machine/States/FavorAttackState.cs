using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorAttackState : State
{
    public override void Enter()
    {
        Debug.Log("Enter Favor Attack");
        if (character.entityFavor.getFavor() >= character.entityFavor.getMaxFavor())  //temp cond
        {
            character.AttackFavorFront();
            character.entityFavor.setFavor(0);
            animator.Play(anim.name);
        }
        else
            Debug.Log("Insufficient Favor for Attack, Attack Failed.");
    }
    public override void Do()
    {
        //if (false /*middle of animation*/)
        //character.AttackNeutralFront();
        if (animationComplete())
            character.isAttackingFavor = false;
    }
    public override void Exit()
    {
        Debug.Log("exit favor attack state");
        character.isAttackingFavor = false;
    }
}
