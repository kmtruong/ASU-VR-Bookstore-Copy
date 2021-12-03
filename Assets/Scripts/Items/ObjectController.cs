using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Creates and Manages ItemObject
 * Attached to all purchasable items
 */
public class ObjectController : MonoBehaviour
{
    private ItemObject item;

    //Creates ItemObject
    public void CreateItemObject(string name, string ID, string info, float price, int amount)
    {
        item = new ItemObject(name, ID, info, price, amount);
    }

    public ItemObject GetItemObject()
    {
        return item;
    }
}
