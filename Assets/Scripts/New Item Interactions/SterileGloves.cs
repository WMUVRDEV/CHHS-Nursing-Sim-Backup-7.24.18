using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SterileGloves : ItemInteraction {

    public bool glovesOn;
    public GameObject ovrLeftHand, ovrRightHand;
    public Material handsMaterialLeft;
    public Material handsMaterialRight;

    public bool inGloveBox;

    private Transform myParent;
   
    public override void Grabbed()
    {
        base.Grabbed();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {

       // Debug.Log(other.name);

        if (other.transform.parent != null)
        {
            myParent = other.transform.parent;
        }


        if (myParent != null)
        {
            if (other.transform.parent.transform.parent.name == "RightController" ||
                other.transform.parent.transform.parent.name == "LeftController")
            {
                inGloveBox = true;
            }
        }


    }
    
    
    private void OnTriggerExit(Collider other)
    {
        inGloveBox = false;
    }

    void Update()
    {
        if ((Input.GetAxis("Axis1D.SecondaryHandTrigger") > 0.01 || Input.GetAxis("Axis1D.PrimaryHandTrigger") > 0.01) && inGloveBox)
        {
            GetGloves();
            Grabbed();
        }
    }

    public void GetGloves()
    {
        glovesOn = true;
        ovrRightHand = GameObject.Find("hand_right_renderPart_0");
        ovrLeftHand = GameObject.Find("hand_left_renderPart_0");
       
        if (ovrLeftHand != null)
        {
            handsMaterialLeft = ovrLeftHand.GetComponent<Renderer>().material;
            handsMaterialLeft.SetColor("_BaseColor", Color.yellow);
        }

        if (ovrRightHand != null)
        {
            handsMaterialRight = ovrRightHand.GetComponent<Renderer>().material;
            handsMaterialRight.SetColor("_BaseColor", Color.yellow);
        }
        
        //just call ungrab here to make life simple??
        
        
    }
    
}
