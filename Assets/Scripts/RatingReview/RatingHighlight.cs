using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RatingHighlight : MonoBehaviour
{
    public int currValue = 0;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;

    public void setCurrValue(int x)
    {
        if (x != currValue)
        {
            star1.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            star2.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            star3.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            star4.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            star5.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);

            currValue = x;

            if(x >= 1)
            {
                star1.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            if (x >= 2)
            {
                star2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            if (x >= 3)
            {
                star3.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            if (x >= 4)
            {
                star4.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            if (x == 5)
            {
                star5.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + "\\Assets\\Scripts\\RatingReview\\pastRating.txt", x.ToString());
        }

        
    }
    void Start()
    {
        star1.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        star2.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        star3.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        star4.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        star5.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        //setCurrValue(5);

    }
}
