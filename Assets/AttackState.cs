using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    Enemy enemy;
    Transform target;
    public AttackState (Agent character) : base(character)
    {
    }

    public override void Play() 
    {
        if (character.transform.GetComponent<FieldOfView>().visibleTargets.Count > 0) Attack();
        else enemy.SetState(new WalkState(character));
    }
    public override void OnStateEnter()
    {
        enemy = character.GetComponent<Enemy>();
    }
    public override void OnStateExit()
    {
        
    }
    void Attack() 
    {
        target = character.transform.GetComponent<FieldOfView>().GetNearest(character.transform.position);
        if (Vector3.Distance(character.transform.position, target.position) > character.distShoot) 
        {
            character.MoveTo(target);
        }
        else character.Shoot();
    }
}
