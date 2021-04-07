using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Image = UnityEngine.UI.Image;

public class CameraMoveScript : MonoBehaviour
{
    private Vector2 mouseSensitivity = new Vector2(2000, -2000);
    private Vector2 acceleration = new Vector2(2000, 2000);
    private Vector2 velocity;
    private Vector2 rotation;
    private Vector2 lastInputEvent;
    private float inputLagPeriod;
    private float inputLagTimer = 0.00005f;
    private float maxVerticleAngleFromHorizon = 90;
    public float moveSpeed = 200;
    private bool cameraControlToggle = true;
    private bool optionMenuToggle;
    private Vector3 position;
    public GameObject buildPanel;
    public GameObject optionMenu;
    private Image crossHair;
    public Text moveSpeedText;
    public Text mouseSensetivePlaceholderText;

    public float MoveSpeed
    {
        get
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                return moveSpeed * 10;
            }
            return moveSpeed;
        }
    }

    private void Start()
    {
        crossHair = GetComponentInChildren<Image>();
        Cursor.visible = false;
    }

    void Update()
    {
        if (cameraControlToggle && !optionMenuToggle)
        {
            var wantedVelocity = GetInput() * mouseSensitivity;
            velocity = new Vector2(
                Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
                Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime));
            rotation += velocity * Time.deltaTime;
            rotation.y = ClampVerticalAngle(rotation.y);
            transform.localEulerAngles = new Vector3(rotation.y,rotation.x,0);

            moveSpeedText.text = moveSpeed.ToString();
            mouseSensetivePlaceholderText.text = mouseSensitivity.x.ToString();
            

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * (MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * (MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * (MoveSpeed * Time.deltaTime); 
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * (MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.up * (MoveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += -transform.up * (MoveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            cameraControlToggle = !cameraControlToggle;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            optionMenuToggle = !optionMenuToggle;
        }
        
        Cursor.visible = !cameraControlToggle || optionMenuToggle;
        Cursor.lockState = !Cursor.visible ? CursorLockMode.Locked : CursorLockMode.None;
        buildPanel.SetActive(!cameraControlToggle);
        crossHair.gameObject.SetActive(!Cursor.visible);
        optionMenu.SetActive(optionMenuToggle);
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

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
