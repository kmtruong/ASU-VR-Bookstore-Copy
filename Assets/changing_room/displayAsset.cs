using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayAsset : MonoBehaviour
{
    public Image displayImage;
    public Text displayName;
    public Button button;
    public Sprite newsprite;
    public void setImage()
    {
        displayImage.sprite = button.GetComponent<Button>().image.sprite;
        displayName.text = button.GetComponent<Button>().image.sprite.name;
    }

    public void setImageColor()
    {
        displayImage.GetComponent<Image>().sprite = newsprite;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
