using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_list : MonoBehaviour
{

    [SerializeField]
    private GameObject item_row;
    [SerializeField]
    private Text subtotal;
    [SerializeField]
    public Text totalQuantity;

    private int numberOfItems;  
    private float totalCost = 0;

    //private items_script items_script1;
    //private List<items_script> items_script2;

    //public GameObject item_script_obj;

    //this is the list of all items in shopping cart
    private List<GameObject> shopping_cart_list;
    private List<GameObject> row_list;
    private GameObject store_row;

    //this is the list of item_rows displayed in checkout menu in respect items in shopping_cart_list
    //private List<GameObject> item_rows;
    
    

    // Start is called before the first frame update
    void Start()
    {
       
        shopping_cart_list = new List<GameObject>();
        row_list = new List<GameObject>();


    }


    public void addItem(GameObject item)
    {
        Debug.Log("shopping_cart_list.Count: " + shopping_cart_list.Count);
        //*****update later so that each product has an itemID*****
        //check another item of the same itemID is already in cart
        bool itemFound = false;
        for(int i = 0; i < shopping_cart_list.Count; i++)
        {
            //Debug.Log("in addItem function itemFound = true");
            //look for item in list
            if (shopping_cart_list[i] != null)
            {
                //is shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject() == null?
                if(shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject() == null)
                {
                    Debug.Log("it is equal to null");
                }
                //**this is the part where we need to check for unique item ID instead of name
                if (shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetName() == item.GetComponent<ObjectController>().GetItemObject().GetName())
                {
                    //if item found in list already, increment amount
                    shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().IncrementAmount(1);
                    
                    //totalCost = totalCost + shopping_cart_list[i].GetPrice();
                    updateTotalCost(item.GetComponent<ObjectController>().GetItemObject().GetPrice());
                    Debug.Log("totalcost" + totalCost);
                    //items_script.total_cost.text = totalCost.ToString();
                    //update amount 
                    row_list[i].GetComponent<items_script>().itemAmount.text = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetAmount().ToString();

                    itemFound = true;
                    Debug.Log("dup item: " + item.name);
                    numberOfItems += 1;
                    //update total num of items
                    totalQuantity.text = numberOfItems.ToString();
                }
            }

        }
        
        
        if(itemFound == false)
        {
            Debug.Log("in addItem function itemFound = false");
            //ItemObject temp = new ItemObject(item.name,"aaa1", "first item",  500.00f, 1);
            //get item object

            shopping_cart_list.Add(item);
            numberOfItems += 1;



            
                
                
            //Debug.Log("cart items: " + shopping_cart_list.Count);
            Debug.Log("ok2");
            store_row = Instantiate(item_row, transform);
            store_row.GetComponent<items_script>().SetID(item.GetComponent<ObjectController>().GetItemObject().GetID());
                

            //set name
            store_row.GetComponent<items_script>().itemName.text = item.GetComponent<ObjectController>().GetItemObject().GetName().ToString();
            //set price
            store_row.GetComponent<items_script>().itemPrice.text = item.GetComponent<ObjectController>().GetItemObject().GetPrice().ToString();
            //set amount 
            store_row.GetComponent<items_script>().itemAmount.text = item.GetComponent<ObjectController>().GetItemObject().GetAmount().ToString();
            Debug.Log("new item: " + store_row.GetComponent<items_script>().itemName.text + " hello");
            //set item desc
            store_row.GetComponent<items_script>().item_desc.text = item.GetComponent<ObjectController>().GetItemObject().GetInfo().ToString();
            //store a copy of row in temp list
            row_list.Add(store_row);



            //update total cost****

            updateTotalCost(item.GetComponent<ObjectController>().GetItemObject().GetPrice());
            //items_script.total_cost.text = totalCost.ToString();
            //Debug.Log("after updating subtotal: " + items_script.total_cost.text);
            Debug.Log("totalcost" + totalCost);
            //update total num of items
            totalQuantity.text = numberOfItems.ToString();
        }
   
    }

    //passed in item_row gameobject
    public void removeItem(GameObject passed_item_row)
    {
        Debug.Log("hello im in removeItem: " + passed_item_row.GetComponent<ObjectController>().GetItemObject().GetName());
        float tempCost = 0;
        int tempAmount = 0;
        GameObject tempItem = null;

        

        //iterate through list to find item
        for (int i = 0; i <shopping_cart_list.Count; i++)
        {

            //get id and find in list and find in list****
            if (shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetName() == passed_item_row.GetComponent<ObjectController>().GetItemObject().GetName())
            {
                //store temp cost and amount 
                tempCost = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetPrice();
                tempAmount = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetAmount();
                tempItem = shopping_cart_list[i];
                numberOfItems -= 1;
                if (tempAmount > 1)
                {
                    shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().DecrementAmount(1);
                    row_list[i].GetComponent<items_script>().itemAmount.text = shopping_cart_list[i].GetComponent<ObjectController>().GetItemObject().GetAmount().ToString();
                }
                else
                {
                    //delete found item from list/shopping cart
                    shopping_cart_list.RemoveAt(i);
                    //delete item row since item is deleted
                    Destroy(row_list[i]);
                    row_list.RemoveAt(i);
                    
                }
                //update total num of items
                totalQuantity.text = numberOfItems.ToString();

            }


        }
        //update total cost
        updateTotalCost(-tempCost);


    }

   

    //update total cost
    private void updateTotalCost(float price)
    {
        totalCost += price;
        subtotal.text = totalCost.ToString();
        

    }


}
