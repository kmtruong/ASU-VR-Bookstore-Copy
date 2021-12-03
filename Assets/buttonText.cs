using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonText : MonoBehaviour
{
    public Text textfield;
    public void SetText()
    {
        if (textfield.text == "Rotate")
        {
            textfield.text = "Stop";
        }
        else
        {
            textfield.text = "Rotate";
        }
    }
}
