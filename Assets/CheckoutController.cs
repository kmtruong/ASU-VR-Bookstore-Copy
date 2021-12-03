using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CheckoutController : MonoBehaviour
{
    private Canvas checkoutCanvas;
  

    // Start is called before the first frame update
    void Start()
    {
        checkoutCanvas = transform.GetComponent<Canvas>();
        checkoutCanvas.enabled = false;


    }

    //If Exit button is clicked on CheckoutUI, then close CheckoutUI
    public void CloseCheckout()
    {
        checkoutCanvas.enabled = false;
    }

    // Update is called once per frame
    
}
