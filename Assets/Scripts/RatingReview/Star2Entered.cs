using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star2Entered : MonoBehaviour
{

    public void setCurrValue()
    {
        transform.parent.gameObject.GetComponent<RatingHighlight>().setCurrValue(2);
    }
}
