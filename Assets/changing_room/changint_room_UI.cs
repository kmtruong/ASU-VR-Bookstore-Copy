using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class changint_room_UI : MonoBehaviour
{
    public Material newMaterial;
    public CanvasGroup canvasGroup;
    public CanvasGroup shirtGroup;
    public CanvasGroup pantsGroup;
    public CanvasGroup longsleeveGroup;
    public CanvasGroup shortsGroup;


    [SerializeField]
    private GameObject clothing_row;
    [SerializeField]
    //private List<changing_test> my_clothing_list;
   // [SerializeField]
    private MeshRenderer clothes;
    private List<GameObject> clothing_list;
    private GameObject store_row;
    private int i;

    private Image img;
    private Text displayName;
    private Button button;

   





    // Start is called before the first frame update
    void Start()
    {
        HideCanvasGroup(shirtGroup);
        HideCanvasGroup(pantsGroup);
        HideCanvasGroup(longsleeveGroup);
        HideCanvasGroup(shortsGroup);
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_shirt_001").GetComponent<MeshRenderer>();
        clothes.enabled = true;
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_pants_001").GetComponent<MeshRenderer>();
        clothes.enabled = true;
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_longsleeve").GetComponent<MeshRenderer>();
        clothes.enabled = false;
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_shorts").GetComponent<MeshRenderer>();
        clothes.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

    }
    


    public void try_shirt()
    {
        clothes = GameObject.Find("/shirt_and_pants_testing/long-sleeve").GetComponent<MeshRenderer>();
        clothes.enabled = false;
        clothes = GameObject.Find("/shirt_and_pants_testing/tshirt").GetComponent<MeshRenderer>();
        clothes.enabled = true;
       
    }

    public void setTSHIRTMaterial(Material newMaterial)
    {
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_shirt_001").GetComponent<MeshRenderer>();
        clothes.GetComponent<MeshRenderer>().material = newMaterial;
    }
    public void setPantsMaterial(Material newMaterial)
    {
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_pants_001").GetComponent<MeshRenderer>();
        clothes.GetComponent<MeshRenderer>().material = newMaterial;
    }
    public void setLongSleeveMaterial(Material newMaterial)
    {
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_longsleeve").GetComponent<MeshRenderer>();
        clothes.GetComponent<MeshRenderer>().material = newMaterial;
    }
    public void setShortssMaterial(Material newMaterial)
    {
        clothes = GameObject.Find("/shirt_and_pants_testing/henry_shorts").GetComponent<MeshRenderer>();
        clothes.GetComponent<MeshRenderer>().material = newMaterial;
    }

    public void HideCanvasGroup(CanvasGroup group)
    {
        group.alpha = 0f; //this makes everything transparent
        group.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public void ShowCanvasGroup(CanvasGroup group)
    {
        group.alpha = 1f;
        group.blocksRaycasts = true;
    }

    public void setTop(bool isT)
    {
        if(isT == true)
        {
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_longsleeve").GetComponent<MeshRenderer>();
            clothes.enabled = false;
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_shirt_001").GetComponent<MeshRenderer>();
            clothes.enabled = true;
        }
        else
        {
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_longsleeve").GetComponent<MeshRenderer>();
            clothes.enabled = true;
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_shirt_001").GetComponent<MeshRenderer>();
            clothes.enabled = false;
        }
        
    }
    public void setBottom(bool isPants)
    {
        if (isPants == true)
        {
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_shorts").GetComponent<MeshRenderer>();
            clothes.enabled = false;
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_pants_001").GetComponent<MeshRenderer>();
            clothes.enabled = true;
        }
        else
        {
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_shorts").GetComponent<MeshRenderer>();
            clothes.enabled = true;
            clothes = GameObject.Find("/shirt_and_pants_testing/henry_pants_001").GetComponent<MeshRenderer>();
            clothes.enabled = false;
        }

    }


}

