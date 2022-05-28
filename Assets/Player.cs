using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    [HideInInspector]
    public Vector3 moveDir;

    float startHeigth;

    public Transform aimTarget;
    public Transform cameraTransform;
    Rigidbody rigi;
    public float JumpForce;
    // Start is called before the first frame update
    void Start()
    {
        startHeigth = transform.position.y;
        rigi = GetComponent<Rigidbody>();
        rigi.maxAngularVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckLive()) 
        {
            SetMaterialByAim();
            PlayerController();
        }
        else Dead();
    }
    void PlayerController() 
    {
        if (Input.GetMouseButtonDown(0)) Shoot(GetTargetAimForGun());
        if (transform.position.y < startHeigth-10) Invoke("EndGame", 2.0f);

        if (Input.GetButton("Jump")) {
            rigi.maxAngularVelocity = 3f;
            rigi.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else rigi.maxAngularVelocity = 0f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0) 
        {
            Vector3 direction = transform.forward * z + transform.right * x;

            moveDir.x = direction.x * speed;
            moveDir.z = direction.z * speed;
        }
        rigi.velocity = new Vector3 (moveDir.x, rigi.velocity.y, moveDir.z);
    }
    Transform GetTargetAimForGun() 
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100.0f)) aimTarget.position = hit.point;
        return aimTarget;
    }
    public override void Dead() 
    {
        base.Dead();
        Invoke("EndGame", 2.0f);
    }
    void SetMaterialByAim() 
    {
        //Debug.Log("kek1");
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 100.0f, 1 << 7)) 
        {
            if (hit.transform.GetComponent<Enemy>() && !hit.transform.GetComponent<Enemy>().onAim) hit.transform.GetComponent<Enemy>().StartCoroutine("SetAsOnAim", 0.5f);
        }
    }
    //GameManager.cs
    void EndGame() 
    {
        GameManager.Instance.EndGame();
    }
}
