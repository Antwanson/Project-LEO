using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool isComplete { get; protected set; }

    protected float startTime;

    public float time => Time.time - startTime;

    public StateController controller;
    public characterController character;

    public AnimationClip anim;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected bool grounded;

    public virtual void Enter() { }//at start of state
    public virtual void Do() { }//continuously throughout state
    public virtual void FixedDo() { }//idk
    public virtual void Exit() { }//at end of state

    public void SetUp(Rigidbody2D _rb, Animator _animator, StateController _controller, characterController _character)
    {
        rb = _rb;
        animator = _animator;
        controller = _controller;
        character = _character;
    }
    public void Initialize()
    {
        isComplete = false;
        startTime = Time.time;
    }
}
