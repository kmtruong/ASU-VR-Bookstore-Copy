using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    public GameObject model;
    public GameObject cloth;
    // Start is called before the first frame update

    public float rotateSpeed = 180f;
    private bool isPressed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            model.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            cloth.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }

    public void TogglePressed(bool value)
    {
        isPressed = value;

    }
}
