using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    public State airState;
    public State idleState;
    public State walkState;
    public State jumpState;
    public State attackState;
    public State dodgeState;

    public StateMachine machine;
    public characterController character;

    public Animator animator;
    public Rigidbody2D rb;

    private void Start()
    {
        idleState.SetUp(rb, animator, this, character);
        walkState.SetUp(rb, animator, this, character);
        airState.SetUp(rb, animator, this, character);
        jumpState.SetUp(rb, animator, this, character);
        attackState.SetUp(rb, animator, this,character);
        dodgeState.SetUp(rb, animator, this, character);

        machine = new StateMachine();
        machine.Set(idleState);
    }

    private void Update()
    {
        SelectState();
        machine.state.Do();
    }
    void SelectState()
    {
        if (Input.GetKeyDown(KeyCode.L))    //dodge state temp
        {
            machine.Set(dodgeState);
        }
        else if (Input.GetKeyDown(KeyCode.P))   //attack state temp
        {
            machine.Set(attackState);
        }
        else if (Input.GetKeyDown(KeyCode.Space)/*|| (!character.isGrounded() && character.y < <apex of jump>)*/)    //jump state
        {
            machine.Set(jumpState);
        }
        else if (character.isGrounded() && character.xDir == 0) //idle state
            machine.Set(idleState);
        else if (character.isGrounded())    //walk state
        {
            machine.Set(walkState);
        }
        else //fall/air state
        {
            machine.Set(airState);
        }
        
    }
}
