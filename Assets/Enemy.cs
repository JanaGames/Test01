using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Agent
{
    private State currentState;
    private FieldOfView FieldOfView;
    NavMeshAgent navMeshAgent;

    void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetState(new WalkState(this));
    }

    void Update() 
    {
        if (CheckLive()) 
        {
            currentState.Play();
        }
        else Dead();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
        gameObject.name = " Enemy curent state: " + state.GetType().Name;

        if (currentState != null)
            currentState.OnStateEnter();
    }

    public override void MoveTo(Transform point)
    {
        if (!MoveStop(point)) 
        {
            FaceTarget(transform, point);
            navMeshAgent.destination = point.position;
        }
    }
    public void MoveToRandom(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
        Vector3 finalPosition = hit.position;
        //Debug.Log(finalPosition);
        navMeshAgent.destination = finalPosition;
        //navMeshAgent.SetDestination(finalPosition);
        //agent.SetDestination (Random.insideUnitSphere * 350);
    }
    public bool MoveStop(Transform target)
    {
        float minDistMove = GetMinDistance(target, transform);
        bool res = false;
        if (Vector3.Distance(transform.position, target.position) <= minDistMove) res = true;
        navMeshAgent.isStopped = res;
        return res;
    }
    public float GetMinDistance(Transform target, Transform origin) 
    {
        float res = 1f;
        Collider targetColl = target.GetComponent<Collider>();
        Collider originColl = origin.GetComponent<Collider>();
        Vector3 closestPoint = targetColl.ClosestPoint(origin.position);
        Vector3 closestPoint2 = originColl.ClosestPoint(target.position);
        res = Vector3.Distance(targetColl.bounds.center, closestPoint);
        res += Vector3.Distance(originColl.bounds.center, closestPoint2);
        res += 1.0f;
        return res;
    }
    public void FaceTarget(Transform origin, Transform target)
    {
        Vector3 direction = (target.position - origin.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        origin.rotation = Quaternion.Slerp(origin.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
