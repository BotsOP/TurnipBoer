using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMouseLook: MonoBehaviour
{
    [SerializeField] private float ofsetX;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    private float xRotation;
    private float zStart;
    private float yStart;
    private float zoom;

    private InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.Zoom.performed += ScrollUpdate;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        zStart = transform.localPosition.z;
        yStart = transform.localPosition.y;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void ScrollUpdate(InputAction.CallbackContext context) 
    {
        float value = context.ReadValue<float>();
        if (value < 0)
        {
            zoom += value;
            if (zoom < -10) 
            { 
                zoom = -10;
            }
        }
        if (value > 0) 
        { 
            zoom+= value;
            if(zoom > 10) 
            { 
                zoom = 10;
            }
        }
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0, 90);
        float ZPos = mapExtention.Map(Mathf.Abs(xRotation), 0, 90, mapExtention.Map(zoom,-10,10,zStart,0), 0);
        float YPos = mapExtention.Map(Mathf.Abs(xRotation), 0, 90, yStart, mapExtention.Map(zoom,0,10,3,0));

        transform.localPosition = new Vector3(transform.localPosition.x,YPos, ZPos);
        transform.localRotation = Quaternion.Euler(xRotation + ofsetX, 0f, 0f + ofsetX);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void SetMouseSensitivity(int newValue)
    {
        mouseSensitivity = newValue;
    }

}

static class mapExtention 
{
    public static float Map(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
    }
}
