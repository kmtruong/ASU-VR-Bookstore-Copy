using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class UserMovement : MonoBehaviour
{
    private Quaternion headDirection;
    public float speed = 1.0f;
    public float additionalHeight = 0.2f;
    public XRNode inputSource;

    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController player;

    void Start()
    {
        player = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        
        //Lock the player's y position to prevent them from flying up or moving down towards the floor
        transform.position = new Vector3(transform.position.x, 1.8f, transform.position.z);
    }

    private void FixedUpdate()
    {
        //Syncing x and z-axis based on the direction that the Player is facing
        headDirection = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0); 

        //Moving Player in x and z-axis of 3D world based on left joystick input
        Vector3 direction = headDirection * (new Vector3(inputAxis.x, 0, inputAxis.y)); 
        player.Move(direction * Time.fixedDeltaTime * speed);
    }

    public Quaternion getHeadDirection()
    {
        return headDirection;
    }
    
}
