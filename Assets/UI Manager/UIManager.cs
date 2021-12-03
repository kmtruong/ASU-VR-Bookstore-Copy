using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
public enum CanvasType
{
    MainMenu,
    miniMapUI,
    checkoutUI,
    helpFaq_UI
}

public class UIManager : MonoBehaviour
{
    public CheckdistanceFromNPC distFromNPC;
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    //Controller Input Detection
    private InputDevice leftController;
    private InputDevice rightController;

    private bool buttonPress;

    public void Start()
    {

        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        
        //MainMenuUI & MiniMapUI Controller Set Up
        leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);


        //CheckOutUI Controller Set Up
        rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        buttonPress = false;
    }


    public void Update()
    {

        //Enable MainMenuUI Canvas
        if ((leftController.TryGetFeatureValue(CommonUsages.menuButton, out buttonPress) && buttonPress) || Input.GetKeyDown("x"))
        {
            SwitchCanvas(CanvasType.MainMenu);
            canvasControllerList.Find(x => x.canvasType == CanvasType.MainMenu).GetComponent<MenuManager>().Pause();

        }

        //Enable MiniMapUI & CheckOutUI Canvas if MainMenuUI is not enabled
        if (!canvasControllerList.Find(x => x.canvasType == CanvasType.MainMenu).gameObject.GetComponent<Canvas>().isActiveAndEnabled)
        
        {
            if ((leftController.TryGetFeatureValue(CommonUsages.primaryButton, out buttonPress) && buttonPress) || Input.GetKeyDown("m"))
            {
                SwitchCanvas(CanvasType.miniMapUI);
                canvasControllerList.Find(x => x.canvasType == CanvasType.miniMapUI).GetComponent<MinimapController>().updateButton();

            }

            if ((rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out buttonPress) && buttonPress) || Input.GetKeyDown("c"))
            {
                SwitchCanvas(CanvasType.checkoutUI);

            }

            if ( distFromNPC.inOrbit || Input.GetKeyDown("f"))
            {
                SwitchCanvas(CanvasType.helpFaq_UI);
            }

        }



    }
    public void SwitchCanvas(CanvasType _type)
    {
        
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.GetComponent<Canvas>().enabled = false;
        }
        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);
        //Debug.Log("Desire Canvas Printed: " + desiredCanvas.name);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.GetComponent<Canvas>().enabled = true;
            lastActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("The desired canvas was not found!"); }
    }

    

    
}

