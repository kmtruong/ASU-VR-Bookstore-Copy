using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class ManageItemsInCart : MonoBehaviour
{
    public GameObject cart;
    public item_list checkoutScript;

    private Collider[] inCart; //items currently in cart
    private Collider[] checkCart; //recent check of items in cart
    private IEnumerable<Collider> newItems; //new items added into cart
    private IEnumerable<Collider> removedItems; //items removed from cart
    
    private Vector3 sphereCenter;
    private float sphereRadius;

    private IEnumerator CheckCart(Vector3 center, float radius)
    {
        checkCart = Physics.OverlapSphere(center, radius);

        //If newItems array isn't equal to inCart array, then add new items
        newItems = checkCart.Except(inCart);

        //If removedItems array isn't equal to inCart array, then remove removed items
        removedItems = inCart.Except(checkCart);

        foreach (Collider items in newItems)
        {
            if (items.tag == "TestObj")
            {
                checkoutScript.addItem(items.gameObject);
            }
        }

        foreach (Collider items in removedItems)
        {
            if (items.tag == "TestObj")
            {
                checkoutScript.removeItem(items.gameObject);
            }
        }

        inCart = checkCart;

        yield return new WaitForSeconds(0.1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        sphereCenter = cart.transform.position;
        sphereRadius = 1f;
        inCart = Physics.OverlapSphere(sphereCenter, sphereRadius);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckCart(sphereCenter, sphereRadius));
    }
}
