using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;
 
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis
 
   
    void Update ()
    {
        if (StateManager.CameraControlToggle && !StateManager.OptionMenuToggle)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");
 
            rotY += mouseX * mouseSensitivity * Time.fixedDeltaTime;
            rotX += mouseY * mouseSensitivity * Time.fixedDeltaTime;
 
            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
 
            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
        }
    }
}