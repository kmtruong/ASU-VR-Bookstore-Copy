using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeepCartDown : MonoBehaviour
{
    public bool isSelected = false;
    public GameObject cart;
    public Transform cameraOffset;
    public UserMovement userMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            cart.transform.rotation = userMovement.getHeadDirection();
        }
    }

    public void fpsOn()
    {
        isSelected = true;
        cart.transform.SetParent(cameraOffset);
    }
    public void fpsOff()
    {
        isSelected = false;
        cart.transform.SetParent(null);
    }
}
