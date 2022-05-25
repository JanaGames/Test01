using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Agent character;

    public abstract void Play();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(Agent character)
    {
        this.character = character;
    }
}
