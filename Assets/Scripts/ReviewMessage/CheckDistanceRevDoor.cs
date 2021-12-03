using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceRevDoor : MonoBehaviour
{
    public GameObject ReviewUI;
    public GameObject XRrig;
    public GameObject RevDoorObj;
    private float distance;
    private bool inProx = false;

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(RevDoorObj.transform.position, XRrig.transform.position);
        if (distance < 8 && inProx == false)
        {
            Debug.Log("Near");
            ReviewUI.GetComponent<ReviewUIControl>().EnableReviewUI();
            inProx = true;
        }
        
        if (distance >= 10 && inProx == true)
        {
            ReviewUI.GetComponent<ReviewUIControl>().CloseReviewUI();
            inProx = false;
        }
    }
}
