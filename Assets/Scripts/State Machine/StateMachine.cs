using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State state;

    

    void SelectState()
    {

    }

    public void Set(State newState, bool forceReset = false)
    {
        if(state != newState || forceReset)
        {
            state?.Exit();
            state = newState;
            state.Initialize();
            state.Enter();
        }
    }
}
