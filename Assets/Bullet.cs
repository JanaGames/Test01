using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeLife;
    public float Damage;
    public GameObject particleTouchBullet;
    //only once
    bool touched = false;

    public void Load(float timeLife, float Damage) 
    {
        this.timeLife = timeLife;
        this.Damage = Damage;
        StartCoroutine(LifeCycle(timeLife));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Gun>()) return;
        if (touched) return;
        touched = true;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GameObject g = Instantiate(particleTouchBullet, transform.position, Quaternion.identity);
        g.transform.parent = transform;
        
        if (other.GetComponent<Agent>()) other.GetComponent<Agent>().Damage(Damage);
        else Invoke("Destroy", 1.0f);
    }
    private IEnumerator LifeCycle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy();
    }
    void Destroy() 
    {
        EventsController.Instance.missEvents.increaseCount(1);
        Destroy(gameObject);
    }
}
