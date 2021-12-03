using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star5Entered : MonoBehaviour
{

    public void setCurrValue()
    {
        transform.parent.gameObject.GetComponent<RatingHighlight>().setCurrValue(5);
    }
}
