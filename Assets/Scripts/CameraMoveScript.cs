using System;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private Vector2 mouseSensitivity = new Vector2(2000, -2000);
    private Vector2 acceleration = new Vector2(2000, 2000);
    private Vector2 velocity;
    private Vector2 rotation;
    private Vector2 lastInputEvent;
    private float inputLagPeriod;
    private float inputLagTimer = 0.005f;
    private float maxVerticleAngleFromHorizon = 90;
    private float moveSpeed = 250;
    private bool cameraControlToggle = true;
    private Vector3 position;
    public GameObject buildPanel;

    void Update()
    {
        if (cameraControlToggle)
        {
            Vector2 wantedVelocity = GetInput() * mouseSensitivity;
            velocity = new Vector2(
                Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
                Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime));
            rotation += velocity * Time.deltaTime;
            rotation.y = ClampVerticalAngle(rotation.y);
            transform.localEulerAngles = new Vector3(rotation.y,rotation.x,0);
            

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * (moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * (moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * (moveSpeed * Time.deltaTime); 
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * (moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.up * (moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += -transform.up * (moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            cameraControlToggle = !cameraControlToggle;
        }

        buildPanel.SetActive(!cameraControlToggle);
    }

    private Vector2 GetInput()
    { 
        inputLagTimer += Time.deltaTime;
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if ((Mathf.Approximately(0, input.x)) && (Mathf.Approximately(0,input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }
        return lastInputEvent;
    }

    private float ClampVerticalAngle(float angle)
    {
        return Mathf.Clamp(angle, -maxVerticleAngleFromHorizon, maxVerticleAngleFromHorizon);
    }

    private void OnEnable()
    {
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastInputEvent = Vector2.zero;

        Vector3 euler = transform.eulerAngles;

        if (euler.x >= 180)
        {
            euler.x -= 360;
        }
        euler.x = ClampVerticalAngle(euler.x);
        transform.eulerAngles = euler;
        rotation = new Vector2(euler.y,euler.x);
    }
}
