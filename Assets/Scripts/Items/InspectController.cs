using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Updates ItemInspection UI
 * Displays Item name, price, and info
 * Attached to all purchasable items
 */
public class InspectController : MonoBehaviour
{
    private GameObject inspectUI;
    private InspectUIManager inspectScript;

    public void SetInspectUI(GameObject inspect)
    {
        inspectUI = inspect;
        inspectScript = inspectUI.GetComponent<InspectUIManager>();
    }

    //XR Grab Interactable: Interactable Events
    //OnHoverEntered
    //Update and show object name and price
    public void ShowName()
    {
        inspectScript.ShowName(gameObject);
    }

    //OnHoverExited
    //Hide object name and price
    public void HideName()
    {
        inspectScript.HideName();
    }

    //OnSelectEntered
    //Update object info and gripPress
    public void GrabbedObject()
    {
        inspectScript.GrabbedObject(gameObject);
    }

    //OnSelectExited
    //Update gripPress
    public void DroppedObject()
    {
        inspectScript.DroppedObject();
    }
}