using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckoutTest : MonoBehaviour
{
    public GameObject row;
    public GameObject itemPrefab;

    private List<string> nameList;

    // Start is called before the first frame update
    void Start()
    {
        nameList = new List<string>();
    }

    public void AddItem(GameObject item)
    {
        if (item.GetComponent<ObjectController>().GetItemObject() != null)
        {
            row.transform.Find("Text").GetComponent<Text>().text = item.GetComponent<ObjectController>().GetItemObject().GetName();
            Instantiate(row, transform);
            //itemList.Add(row);
            nameList.Add(item.GetComponent<ObjectController>().GetItemObject().GetName());
        }
        else
        {
            print("item null");
        }
    }

    public void DeleteItem(GameObject item)
    {
        for (int i = 0; i < nameList.Count; i++)
        {
            if (item.GetComponent<ObjectController>().GetItemObject().GetName() == nameList[i])
            {
                nameList.Remove(nameList[i]);
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    private void RemoveRow()
    {
        Destroy(transform.GetChild(1).gameObject);
    }
}
