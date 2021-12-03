using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


[System.Serializable]
public class Inventory
{
    public List<Itemtype> inventory;
}

[System.Serializable]
public class Itemtype
{
    public string type;
    public List<Item> item;
}

[System.Serializable]
public class Item
{
    public string ID;
    public string Name;
    public string Type;
    public float Weight;
    public string Size;
    public string Dimension;
    public string Info;
    public float Price;
    public int Amount;
    public int ToSpawn;
    public string Date;
}




public class ItemManager : MonoBehaviour
{
    public GameObject GO;
    private bool CheckSurrounding(Vector3 center)
    {
        // Do check for collision with Grab (Grab layer is number 8)
        int layerMask = 1 << 8;
        //layerMask = ~layerMask;
        bool isOccupied = false;

        // Pass in any object that collides in a adjustable radius
        Collider[] hitColliders = Physics.OverlapSphere(center, 2, layerMask);

        // If any object in there, don't teleport
        foreach(Collider collider in hitColliders)
        {
            //Debug.Log("In foreach");
            if (collider.tag == "TestObj")
            {
                //Debug.Log("Hit object");
                isOccupied = true;
            }    
        }
        return isOccupied;
    }

    public TextAsset db;
    public GameObject itemprefab;
    public Transform cameraOffset;
    public GameObject itemInspection; //add inspectionUI to items
    private GameObject inspect;
    bool notInstantiated;
    bool notSpawned;
    public Inventory inventory;
    public GameObject copyprefab;

    private TextMesh text;
    //private GameObject inspect;





    void Start()
    {
        notInstantiated = true;
        notSpawned = true;
        inspect = Instantiate(itemInspection, cameraOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (notInstantiated)
        {
            /*GameObject*/ //copyprefab = Instantiate(itemprefab, transform);
            /*Inventory*/ inventory = JsonUtility.FromJson<Inventory>(db.text);
            // Spawning out of stock items
            foreach (Itemtype itemtype in inventory.inventory)
            {
                foreach (Item item in itemtype.item)
                {
                    if (item.ToSpawn == 0)
                    {
                        //Debug.Log(item.ID + " " + item.Name + " " + item.Price + " " + item.Type + " " + item.Size);
                        //var go = Instantiate(copyprefab, Vector3.zero, Quaternion.identity);
                        var go = Instantiate(Resources.Load(item.Name), Vector3.zero, Quaternion.identity) as GameObject;
                        go.GetComponent<InspectController>().SetInspectUI(inspect);
                        //go.GetComponent<InstantiatingPrefab>().myPrefab = ;
                        go.AddComponent<ItemObject>();
                        go.GetComponent<ItemObject>().SetID(item.ID);
                        go.GetComponent<ItemObject>().SetName(item.Name);
                        go.GetComponent<ItemObject>().SetType(item.Type);
                        go.GetComponent<ItemObject>().SetWeight(item.Weight);
                        go.GetComponent<ItemObject>().SetSize(item.Size);
                        go.GetComponent<ItemObject>().SetDimension(item.Dimension);
                        go.GetComponent<ItemObject>().SetInfo(item.Info);
                        go.GetComponent<ItemObject>().SetPrice(item.Price);
                        go.GetComponent<ItemObject>().SetAmount(item.Amount);
                        go.GetComponent<ItemObject>().SetDate(item.Date);
                        go.name = go.GetComponent<ItemObject>().GetName();
                        //go.tag = "Item";
                        // set gravity = false;
                        //go.GetComponent<Rigidbody>().useGravity = false;

                        Vector3 temp;
                        switch (go.GetComponent<ItemObject>().GetType())
                        {
                            case "Book":
                                temp = GameObject.Find("BookSpawningPoint").transform.position;
                                go.transform.position = temp;

                                break;
                            case "Clothing":
                                if (go.GetComponent<ItemObject>().GetName() == "ASU Beanie")
                                    temp = GameObject.Find("BeanieSpawningPoint").transform.position;
                                else
                                    temp = GameObject.Find("HoodieSpawningPoint").transform.position;
                                go.transform.position = temp;
                                break;
                            case "Office":
                                temp = GameObject.Find("OfficeSpawningPoint").transform.position;
                                go.transform.position = temp;
                                break;
                            case "Souvenir":
                                temp = GameObject.Find("CupSpawningPoint").transform.position;
                                go.transform.position = temp;
                                break;
                            default:
                                break;
                        }

                        //go.GetComponent<XRGrabInteractable>().enabled = false;
                        go.GetComponent<XRGrabInteractable>().interactionLayerMask = 0;

                        var rend = go.GetComponent<Renderer>();
                        rend.material.SetColor("_Color", Color.gray);


                        // Adding OUT OF STOCK MESH
                        Vector3 loc = go.transform.position;
                        loc.y += .5f;
                        Vector3 rote = go.transform.rotation.eulerAngles;
                        spawnOOS(loc, rote);
                        loc.y -= .5f;
                        spawnBackIn(loc, rote, item.Date);

                    }

                }
                //copyprefab.GetComponent<ObjectController>().CreateItemObject(item.GetName(), item.GetID(), item.GetInfo(), item.GetPrice(), 0, item.GetAmountInStock());
                //copyprefab.GetComponent<InspectController>().SetInspectUI(inspect);
            }
            notInstantiated = false;
        }


        // Spawning in stock items
        foreach (Itemtype itemtype in inventory.inventory)
        {
            //Debug.Log(itemtype.type);
            foreach (Item item in itemtype.item)
            {
                if (item.ToSpawn > 0)
                {
                    //Debug.Log(item.ID + " " + item.Name + " " + item.Price + " " + item.Type + " " + item.Size);
                    //var go = Instantiate(copyprefab, Vector3.zero, Quaternion.identity);
                    var go = Instantiate(Resources.Load(item.Name), Vector3.zero, Quaternion.identity) as GameObject;
                    go.GetComponent<InspectController>().SetInspectUI(inspect);
                    go.AddComponent<ItemObject>();
                    go.GetComponent<ItemObject>().SetID(item.ID);
                    go.GetComponent<ItemObject>().SetName(item.Name);
                    go.GetComponent<ItemObject>().SetType(item.Type);
                    go.GetComponent<ItemObject>().SetWeight(item.Weight);
                    go.GetComponent<ItemObject>().SetSize(item.Size);
                    go.GetComponent<ItemObject>().SetDimension(item.Dimension);
                    go.GetComponent<ItemObject>().SetInfo(item.Info);
                    go.GetComponent<ItemObject>().SetPrice(item.Price);
                    go.GetComponent<ItemObject>().SetAmount(item.Amount);
                    go.name = go.GetComponent<ItemObject>().GetName();
                    //go.tag = "Item";
                    // set gravity = false;
                    //go.GetComponent<Rigidbody>().useGravity = false;

                    Vector3 temp;
                    bool isOccupied;
                    switch (go.GetComponent<ItemObject>().GetType())
                    {
                        case "Book":
                            temp = GameObject.Find("BookSpawningPoint").transform.position;
                            //Debug.Log(temp);
                            isOccupied = CheckSurrounding(temp);
                            //Debug.Log(isOccupied);
                            while (isOccupied)
                            {
                                temp.z = temp.z + 2;
                                //Debug.Log(temp);
                                isOccupied = CheckSurrounding(temp);
                            }
                            go.transform.position = temp;

                            break;
                        case "Clothing":
                            if (go.GetComponent<ItemObject>().GetName() == "ASU Beanie")
                                temp = GameObject.Find("BeanieSpawningPoint").transform.position;
                            else
                                temp = GameObject.Find("HoodieSpawningPoint").transform.position;
                            //Debug.Log(temp);
                            isOccupied = CheckSurrounding(temp);
                            //Debug.Log(isOccupied);
                            while (isOccupied)
                            {
                                temp.x = temp.x + 0.2f;
                                //Debug.Log(temp);
                                isOccupied = CheckSurrounding(temp);
                            }
                            go.transform.position = temp;
                            break;
                        case "Office":
                            temp = GameObject.Find("OfficeSpawningPoint").transform.position;
                            //Debug.Log(temp);
                            isOccupied = CheckSurrounding(temp);
                            //Debug.Log(isOccupied);
                            while (isOccupied)
                            {
                                temp.z = temp.z + 2;
                                //Debug.Log(temp);
                                isOccupied = CheckSurrounding(temp);
                            }
                            go.transform.position = temp;
                            break;
                        case "Souvenir":
                            temp = GameObject.Find("CupSpawningPoint").transform.position;
                            while (CheckSurrounding(temp))
                            {
                                temp.z = temp.z + 2;
                            }
                            go.transform.position = temp;
                            break;
                        default:
                            break;
                    }
                    item.ToSpawn = item.ToSpawn - 1;
                }
                    
            }
            //copyprefab.GetComponent<ObjectController>().CreateItemObject(item.GetName(), item.GetID(), item.GetInfo(), item.GetPrice(), 0, item.GetAmountInStock());
            //copyprefab.GetComponent<InspectController>().SetInspectUI(inspect);
        }

        


    }
    

    private void spawnOOS(Vector3 spawnPosition, Vector3 rote)
    {
        GameObject oosLogo = Instantiate(GO, spawnPosition, Quaternion.identity);
        oosLogo.transform.Rotate(rote);
    }

    private void spawnBackIn(Vector3 spawnPosition, Vector3 rote, string dateVal)
    {

        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject oosBack = new GameObject();
        oosBack.AddComponent<TextMesh>();
        text = oosBack.GetComponent<TextMesh>();
        text.text = dateVal;
        text.font = arial;
        text.fontSize = 14;
        text.color = Color.red;
        Vector3 changeVec = new Vector3(-0.07f, 0.07f, oosBack.transform.localScale.z);
        oosBack.transform.localScale -= new Vector3(1.0f, 1.0f, 1.0f);
        oosBack.transform.localScale += changeVec;
        oosBack.transform.position = spawnPosition;
        oosBack.transform.Rotate(rote);


    }
}
