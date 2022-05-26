using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float health = 100f;
    public float speed = 2f;
    public float distShoot;

    public virtual void MoveTo(Transform point) {}

    public virtual void Shoot(Transform targetLook) {}

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
}
