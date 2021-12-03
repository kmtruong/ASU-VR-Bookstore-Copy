using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star4Entered : MonoBehaviour
{
   /*for testing on pc
    * public int y;
    private void Update()
    {
        if (y % 20 == 0)
        {
            int xcount = Random.Range(1, 6);
            transform.parent.gameObject.GetComponent<RatingHighlight>().setCurrValue(xcount);
        }
        y++;
    }*/
    public void setCurrValue()
    {
        transform.parent.gameObject.GetComponent<RatingHighlight>().setCurrValue(4);
    }
}
