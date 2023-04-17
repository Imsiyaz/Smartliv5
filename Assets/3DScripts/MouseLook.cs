using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //setting mouse sens and multiplying it by the x and y axis where we are rotating the camera
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //we multiply by time delta time as regardless of the framerate the turning of the camera would be the same
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //We are clamping the rotation of the camera so that it doesnt rotate all the way back when looking up
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //we are rotating the Y axis of the player which amkes the camera move from left to right
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
