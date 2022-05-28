using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefub;
    public float speed;
    public Transform shootPos;
    public float ShootingDelay = 1.0f;
    public float Damage;
    public float weaponRange;
    bool readyShoot = true;

    void Start()
    {
        
    }

    public void Shoot(Transform targetLook) 
    {
        if (readyShoot) 
        {
            transform.LookAt(targetLook);
            readyShoot = false;
            GameObject bullet = Instantiate(bulletPrefub, shootPos.position, shootPos.rotation)                          
                as GameObject;
            bullet.GetComponent<Bullet>().Load(3.0f, Damage);
            bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            Invoke("SetReadyShoot", ShootingDelay);
        }
    }
    void SetReadyShoot() { readyShoot = true; }
}