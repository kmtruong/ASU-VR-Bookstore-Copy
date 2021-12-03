using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star1Entered : MonoBehaviour
{
    // Start is called before the first frame update

    public void setCurrValue()
    {
        transform.parent.gameObject.GetComponent<RatingHighlight>().setCurrValue(1);
    }
}
