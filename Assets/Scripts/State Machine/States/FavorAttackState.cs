using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavorAttackState : State
{
    public override void Enter()
    {
        Debug.Log("Favor Attack");
        if(true/*character.entityFavor.currentFavor >= character.entityFavor.maxFavor*/)  //temp cond
        {
            character.AttackFavorFront();
            //Animator.Play(anim.name);
        }
    }
    public override void Do()
    {
        //if (false /*middle of animation*/)
            //character.AttackNeutralFront();
        if (true/*animation ends || favor < maxfavor*/)
          character.isAttackingFavor = false;
    }
    public override void Exit()
    {
        Debug.Log("exit favor attack state");
        character.isAttackingFavor = false;
        //favor = 0;
    }
}
