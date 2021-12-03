using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour
{
    private Canvas keyboardCanvas;
    //private string inputText;
    private Text inputText;
    private bool shift;

    private void Start()
    {
        keyboardCanvas = gameObject.GetComponent<Canvas>();
        keyboardCanvas.enabled = false;
        shift = false;
    }

    public void OpenKeyboard(Text inputFieldText)
    {
        keyboardCanvas.enabled = true;
        inputFieldText.text = "";
        inputText = inputFieldText;
    }

    public void CloseKeyboard()
    {
        keyboardCanvas.enabled = false;
    }

    public void KeyPressed(string letter)
    {
        if (shift)
        {
            inputText.text += letter.ToUpper();
        }
        else
        {
            inputText.text += letter;
        }
    }

    public void DeleteLetter()
    {
        if (inputText.text.Length > 0)
        {
            inputText.text = inputText.text.Substring(0, inputText.text.Length - 1);
        }
    }

    public void ShiftPressed(Image shiftButton)
    {
        if (!shift)
        {
            shift = true;
            shiftButton.color = Color.green;
        }
        else
        {
            shift = false;
            shiftButton.color = Color.white;
        }
    }

    public void SpacePressed()
    {
        inputText.text += " ";
    }

    public void SpecialCharPressed(string specialChar)
    {
        inputText.text += specialChar;
    }
}
