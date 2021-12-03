using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

/*
 * Manages and Updates ItemInspection UI
 * Displays Item name, price, and info
 */
public class InspectUIManager : MonoBehaviour
{
    //Controller Input Source
    public XRNode inputSource;

    //ItemInspection UI Elements
    //[SerializeField] private GameObject inspectUIBG;
    [SerializeField] private Text objectNameText;
    //[SerializeField] private GameObject objectPriceUI;
    [SerializeField] private Text objectPriceText;
    //[SerializeField] private GameObject objectInfoUI;
    [SerializeField] private Text objectInfoText;

    private Canvas inspectUI;

    //Controller Input Detection
    private InputDevice device;
    private bool gripPress;
    private bool lastButtonPress;

    private void Start()
    {
        //Initialize device based on Input Source
        device = InputDevices.GetDeviceAtXRNode(inputSource);

        //Disable ItemInspection UI 
        //inspectUIBG.SetActive(false);
        inspectUI = transform.GetComponent<Canvas>();
        inspectUI.enabled = false;

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
                //objectInfoUI.SetActive(!objectInfoUI.activeSelf);
            }

            lastButtonPress = buttonPress;
        }
    }

    //XR Grab Interactable: Interactable Events
    //OnHoverEntered
    //Update and show object name and price
    public void ShowName(GameObject item)
    {
        inspectUI.enabled = true;
        //objectPriceUI.SetActive(true);

        //set item info
        //objectInfoUI.SetActive(true);
        objectInfoText.text = item.GetComponent<ItemObject>().GetInfo();
        //set NameText to item name
        objectNameText.text = item.GetComponent<ItemObject>().GetName();

        //set PriceText to item price
        objectPriceText.text = item.GetComponent<ItemObject>().GetPrice().ToString();
    }

    //OnHoverExited
    //Hide object name and price
    public void HideName()
    {
        if (!gripPress)
        {
            inspectUI.enabled = false;
            //inspectUIBG.SetActive(false);
            //objectPriceUI.SetActive(false);
            //objectInfoUI.SetActive(false);
        }
    }

    //OnSelectEntered
    //Update object info and gripPress
    public void GrabbedObject(GameObject item)
    {
        //inspectUIBG.SetActive(true);
        //objectPriceUI.SetActive(true);
        inspectUI.enabled = true;

        //set InfoText to item info
        objectInfoText.text = item.GetComponent<ItemObject>().GetInfo();
        gripPress = true; //User is holding object
    }

    //OnSelectExited
    //Update gripPress
    public void DroppedObject()
    {
        gripPress = false; //User dropped object
        //inspectUIBG.SetActive(false);
        //objectPriceUI.SetActive(false);
        inspectUI.enabled = false;
    }
}
