using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatingPrefab : MonoBehaviour
{
    public GameObject myPrefab;
    void Start()
    {
        Instantiate(myPrefab);
    }
}
