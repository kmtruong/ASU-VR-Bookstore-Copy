using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform firstPersonBody;
    public Canvas minimap;
     
    

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameObject temp = GameObject.Find("MiniMapCanvas");
        minimap = temp.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (minimap.enabled)
        {
            mouseSensitivity = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            mouseSensitivity = 100f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        firstPersonBody.Rotate(Vector3.up * mouseX);
    }
}
