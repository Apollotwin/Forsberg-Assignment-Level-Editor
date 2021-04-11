using UnityEngine;
public class CameraMoveScript : MonoBehaviour
{
    public float moveSpeed = 200;
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

    void Update()
    {
        if (StateManager.CameraControlToggle && !StateManager.OptionMenuToggle)
        {
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
    }


}
