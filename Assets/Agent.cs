using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;
    public float distShoot;

    public virtual void MoveTo(Transform point) {}

    public virtual void Shoot(Transform targetLook) 
    {
        if (GetComponentInChildren<Gun>()) 
        {
            GetComponentInChildren<Gun>().Shoot(targetLook);
        }
    }

    public virtual void Alert() {}

    public virtual bool CheckLive() 
    {
        return health > 0;
    }

    public virtual void Jump() {}

    public virtual void Dead() 
    {
        StopAllCoroutines();
    }
    public virtual void Damage(float damage) 
    {
        health -= damage;
    }
}
