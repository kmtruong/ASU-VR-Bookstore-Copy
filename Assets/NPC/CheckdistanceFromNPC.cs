using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckdistanceFromNPC : MonoBehaviour
{
    public GameObject target;
    public GameObject NPC;
    public float dist;
    public Animator anim;
    public bool inOrbit = false;
    public AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(NPC.transform.position, target.transform.position);
        //Debug.Log(dist);
        if (dist < 6 && inOrbit == false)
        {
            anim.SetBool("EnteredNPCArea",true);
            inOrbit = true;
            aSource.Play();
        }

        if (dist >= 8)
        {
            anim.SetBool("EnteredNPCArea", false);
            inOrbit = false;
        }
    }
}
