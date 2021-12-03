using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class InspectTest : MonoBehaviour
{
    //Controller Input Source
    public XRNode inputSource;

    //ItemInspection UI Elements
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Text objectNameText;
    [SerializeField] private Text objectPriceText;
    [SerializeField] private GameObject objectInfoUI;
    [SerializeField] private Text objectInfoText;

    //Controller Input Detection
    private InputDevice device;
    private bool gripPress;
    private bool lastButtonPress;

    private void Start()
    {
        //Initialize device based on Input Source
        device = InputDevices.GetDeviceAtXRNode(inputSource);

        //Disable ItemInspection UI 
        itemUI.SetActive(false);
        objectInfoUI.SetActive(false);

        //Initialize booleans for input detection
        gripPress = false;
        lastButtonPress = false;
    }

    //If User is grabbing an item, then show/hide item name and description on button hold (A)
    private void Update()
    {
        if (gripPress && device.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonPress))
        {
            if (buttonPress != lastButtonPress)
            {
                objectInfoUI.SetActive(!objectInfoUI.activeSelf);
            }

            lastButtonPress = buttonPress;
        }
    }

    //XR Grab Interactable: Interactable Events
    //OnHoverEntered
    //Update and show object name and price
    public void ShowName(GameObject item)
    {
        //set NameText to item name
        objectNameText.text = item.GetComponent<ObjectController>().GetItemObject().GetName();
        //set PriceText to item price
        objectPriceText.text = item.GetComponent<ObjectController>().GetItemObject().GetPrice().ToString();
        itemUI.SetActive(true);
    }

    //OnHoverExited
    //Hide object name and price
    public void HideName()
    {
        itemUI.SetActive(false);
    }

    //OnSelectEntered
    //Update object info and gripPress
    public void GrabbedObject(GameObject item)
    {
        //set InfoText to item info
        objectInfoText.text = item.GetComponent<ObjectController>().GetItemObject().GetInfo();
        gripPress = true; //User is holding object
    }

    //OnSelectExited
    //Update gripPress
    public void DroppedObject()
    {
        gripPress = false; //User dropped object
        //Uncomment below statement if they don't hide automatically after releasing object
        //itemUI.SetActive(false);
        //objectInfoUI.SetActive(false); 
    }
}
