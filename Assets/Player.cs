using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    [HideInInspector]
    public Vector3 moveDir;
    [HideInInspector]
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckLive()) PlayerController();
        else Dead();
    }
    void PlayerController() 
    {
        if (controller.isGrounded && Input.GetButton("Jump")) {
         moveDir.y = 3f;
        }
        moveDir.y -= 9.8f * Time.deltaTime;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0) 
        {
            Vector3 direction = transform.forward * z + transform.right * x;

            moveDir.x = direction.x * speed;
            moveDir.z = direction.z * speed;

            controller.Move(moveDir * Time.deltaTime);
        }
    }
}
