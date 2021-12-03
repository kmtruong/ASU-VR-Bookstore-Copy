using UnityEngine;

/*
 * Manages ItemObject properties
 * Allows Checkout and ItemInspection scripts to easily retrieve an item's properties/details
 */
[System.Serializable]
public class ItemObject : MonoBehaviour
{
    /*
     * Add ID to constructor
     * Add getter and setter for ID
     */
    //ItemObject properties
    private string ID; //unique item ID
    private string Name;
    private string Type;
    private float Weight;
    private string Size;
    private string Dimension;
    private string Info; //item description
    private float Price;
    private int Amount; //quantity in cart
    private string Date;

    //ItemObject constructor
    public ItemObject(string itemName, string itemID, string itemInfo, float itemPrice, int itemAmount)
    {
        Name = itemName;
        ID = itemID;
        Info = itemInfo;
        Price = itemPrice;
        Amount = itemAmount;
    }

    //Setters for each ItemObject property
    public void SetID(string itemID)
    {
        ID = itemID;
    }
    public void SetName(string itemName)
    {
        Name = itemName;
    }
    public void SetType(string itemType)
    {
        Type = itemType;
    }
    public void SetWeight(float itemWeight)
    {
        Weight = itemWeight;
    }
    public void SetSize(string itemSize)
    {
        Size = itemSize;
    }
    public void SetDimension(string itemDimension)
    {
        Dimension = itemDimension;
    }
    public void SetInfo(string itemInfo)
    {
        Info = itemInfo;
    }
    public void SetPrice(float itemPrice)
    {
        Price = itemPrice;
    }
    public void SetAmount(int itemAmount)
    {
        Amount = itemAmount;
    }
    public void SetDate(string itemDate)
    {
        Date = itemDate;
    }

    //Getters for each ItemObject property
    public string GetID()
    {
        return ID;
    }
    public string GetName()
    {
        return Name;
    }
    public new string GetType()
    {
        return Type;
    }
    public float GetWeight()
    {
        return Weight;
    }
    public string GetSize()
    {
        return Size;
    }
    public string GetDimension()
    {
        return Dimension;
    }
    public string GetInfo()
    {
        return Info;
    }
    public float GetPrice()
    {
        return Price;
    }
    public int GetAmount()
    {
        return Amount;
    }
    public string GetDate()
    {
        return Date;
    }

    //Increment/Decrement Amount based on parameter value
    public void IncrementAmount(int increment)
    {
        Amount += increment;
    }
    public void DecrementAmount(int decrement)
    {
        Amount -= decrement;
    }
}