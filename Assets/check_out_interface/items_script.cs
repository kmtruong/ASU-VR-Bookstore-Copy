using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class items_script : MonoBehaviour
{

    private string id;
    //item name
    public Text itemName;

    //item price
    public Text itemPrice;

    //item amount
    public Text itemAmount;


    //item desc
    public Text item_desc;

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetID()
    {
        return id;
    }

    public void SetID(string passed_id)
    {
        id = passed_id;
    }

}
