using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseTest : MonoBehaviour
{
    public Transform cameraOffset;
    public GameObject itemInspection;
    public GameObject itemPrefab;
    private List<string> names;
    private GameObject inspect;

    // Start is called before the first frame update
    void Start()
    {
        inspect = Instantiate(itemInspection, cameraOffset);
        names = new List<string>();
        names.Add("Hello");
        names.Add("World!");
        Test();
    }

    //Test that Database can set up ItemPrefab
    private void Test()
    {
        //Instantiating first item into Scene
        GameObject copyPrefab = Instantiate(itemPrefab, transform);
        copyPrefab.GetComponent<ObjectController>().CreateItemObject(names[0], "abc123", "this is just a test.", 500.00f, 1);
        copyPrefab.GetComponent<InspectController>().SetInspectUI(inspect);

        //Instantiating second item into Scene
        copyPrefab = Instantiate(itemPrefab, transform);
        copyPrefab.GetComponent<ObjectController>().CreateItemObject(names[1], "def456", "Has a sprinkle of innovation", 1.00f, 1);
        copyPrefab.GetComponent<InspectController>().SetInspectUI(inspect);
    }
}