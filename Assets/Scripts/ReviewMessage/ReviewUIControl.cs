using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewUIControl : MonoBehaviour
{
    private Canvas ReviewUICanvas;
    void Start()
    {
        ReviewUICanvas = transform.GetComponent<Canvas>();
        ReviewUICanvas.enabled = false;
    }
    public void OpenWebsite()
    {
        Application.OpenURL("http://google.com");
        ReviewUICanvas.enabled = false;
    }

    public void EnableReviewUI()
    {
        ReviewUICanvas.enabled = true;
    }
    public void CloseReviewUI()
    {
        ReviewUICanvas.enabled = false;
    }
}
