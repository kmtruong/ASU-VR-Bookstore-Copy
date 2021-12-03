using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;



public enum ClothesType
{
    topTShirt,
    topLongSleeve,
    botPants,
    botShorts

}

public class ClothesManager : MonoBehaviour
{
    private List<ClothesController> clothesControllerList;
    private ClothesController activeUpperClothing;
    private ClothesController activeBottomClothing;
    public Text clothesName;

    // Start is called before the first frame update
    public void Start()
    {
        clothesControllerList = GetComponentsInChildren<ClothesController>().ToList();
        foreach (ClothesController clothing in clothesControllerList)
        {
            clothing.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    
    public void changeClothing()
    {
        if (!clothesName.text.Equals("Name"))
        {
            ClothesController desiredClothing = clothesControllerList.Find(x => x.name.ToString().Equals(clothesName.text));
            if (desiredClothing != null)
            {
                string clothBody = desiredClothing.clothesType.ToString();
                if (clothBody.Substring(0, 3).Equals("top"))
                {
                    switchTopClothing(desiredClothing);
                }
                if (clothBody.Substring(0, 3).Equals("bot"))
                {
                    switchBottomClothing(desiredClothing);
                }
            }
            
        }
    }

    // Update is called once per frame
    private void switchTopClothing(ClothesController desiredTop)
    {
        if (activeUpperClothing != null)
        {
            activeUpperClothing.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        ClothesController desiredUpperClothing = desiredTop;


        desiredUpperClothing.gameObject.GetComponent<MeshRenderer>().enabled = true;
        activeUpperClothing = desiredUpperClothing;

    }

    private void switchBottomClothing(ClothesController desiredBot)
    {
        if (activeBottomClothing != null)
        {
            activeBottomClothing.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        ClothesController desiredBottomClothing = desiredBot;


        desiredBottomClothing.gameObject.GetComponent<MeshRenderer>().enabled = true;
        activeBottomClothing = desiredBottomClothing;

    }


}
