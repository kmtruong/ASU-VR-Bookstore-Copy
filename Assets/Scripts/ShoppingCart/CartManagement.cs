using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartManagement : MonoBehaviour
{
    public CheckoutTest checkoutScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TestObj")
        {
            other.transform.tag = "Cart";
            Debug.Log("Added: " + other.gameObject.name);
            checkoutScript.AddItem(other.gameObject);
        }
        else if (other.gameObject.tag == "Cart")
        {
            other.transform.tag = "TestObj";
            Debug.Log("Removed: " + other.gameObject.name);
            checkoutScript.DeleteItem(other.gameObject);
        }
    }

    /*
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cart")
        {
            other.transform.tag = "TestObj";
            Debug.Log("Removed: " + other.gameObject.name);
        }
    }
    */
}
