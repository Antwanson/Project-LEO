using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{

    public State airState;
    public State idleState;
    public State walkState;

    public StateMachine machine;
    public characterController character;

    public Animator animator;
    public Rigidbody2D rb;

    private void Start()
    {
        idleState.SetUp(rb, animator, this, character);
        walkState.SetUp(rb, animator, this, character);
        airState.SetUp(rb, animator, this, character);

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

        if (character.isGrounded() && character.xDir == 0)
            machine.Set(idleState);
        else if(character.isGrounded())
            machine.Set(walkState);
        else
            machine.Set(airState);
        
    }
}
