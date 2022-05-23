using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
       // Cursor.lockState = CursorLockMode.Locked;
        float mouseX = input.x;
        float mouseY = input.y;

        //calculate rotation of camera
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // apply to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // rotate player
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
