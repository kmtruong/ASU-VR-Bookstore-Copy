using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star3Entered : MonoBehaviour
{
    public void setCurrValue()
    {
        transform.parent.gameObject.GetComponent<RatingHighlight>().setCurrValue(3);
    }
}
