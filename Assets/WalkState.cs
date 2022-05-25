using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    Enemy enemy;
    public WalkState (Agent character) : base(character)
    {
    }

    public override void Play() 
    {
        if (character.transform.GetComponent<FieldOfView>().visibleTargets.Count == 0) Walk();
        else enemy.SetState(new AttackState(character));
    }
    public override void OnStateEnter()
    {
        enemy = character.GetComponent<Enemy>();
    }
    public override void OnStateExit()
    {
        
    }

    public void Walk() 
    {
        enemy.MoveToRandom(2f);
    }
}
