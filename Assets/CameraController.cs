using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    public float rotationSpeed;
    float mouseX, mouseY;
    public bool _pause;

    private Vector3 camOffset;

    float min;
    float max;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pause = false;
        camOffset = new Vector3(0, 2, -5);
        min = -25f;
        max = 60f;
    }

    void Update()
    {
        if (!_pause)
        {
            CamControl();
        }
    }
    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X");
        mouseY -= Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, min, max);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //for first view not need
            //targetCamera.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
}
