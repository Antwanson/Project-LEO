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
    public State hurtState;
    public State deadState;

    public StateMachine machine;
    public characterController character;
    public EntityHealth health;

    public Animator animator;
    public Rigidbody2D rb;

    private void Start()
    {
        health = gameObject.GetComponent<EntityHealth>();

        idleState.SetUp(rb, animator, this, character);
        walkState.SetUp(rb, animator, this, character);
        airState.SetUp(rb, animator, this, character);
        jumpState.SetUp(rb, animator, this, character);
        attackState.SetUp(rb, animator, this,character);
        dodgeState.SetUp(rb, animator, this, character);
        hurtState.SetUp(rb, animator, this, character);
        deadState.SetUp(rb, animator, this, character);

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
        //hurt/dead states
        if (health.currentHealth <= 0)
        {
            machine.Set(deadState);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.H)/*hurt*/)
        {
            machine.Set(hurtState);
        }

        //idle or walk state
        else if (character.isGrounded() && character.xDir == 0)
        {
            machine.Set(idleState);
        }
        else if (character.isGrounded())
        {
            machine.Set(walkState);
        }


        //air state
        else if (Input.GetKeyDown(KeyCode.Space) || (!character.isGrounded() && rb.velocity.y > 0))    //jump state
            machine.Set(jumpState);
        else if (!character.isGrounded())//fall/air state
            machine.Set(airState);

        //attack states
        else if (Input.GetKeyDown(KeyCode.L) && character.isGrounded())    //dodge state, swap button for actual input l8r
        {
            machine.Set(dodgeState);
        }
        else if (Input.GetKeyDown(KeyCode.P))   //attack state, swap button for actual input l8r
        {
            machine.Set(attackState);
        }


    }
}
