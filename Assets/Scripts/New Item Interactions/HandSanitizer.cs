using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using Obi;
using UnityEngine;

public class HandSanitizer : ItemInteraction {

    public AudioClip dispenseClip;
    public AudioClip contactClip;

    public GameObject sanitizerDollop;
    public Transform dispensePoint;
   
    public GameObject rightHand, leftHand;
    public Collider saniCollider;

    public bool dispensing;
    public bool leftSanitized;
    public bool rightSanitized;
    private string activeHand;

    public ParticleSystem sanitizerParticles;

    public override void Grabbed()
    {
        base.Grabbed();
    }
    
    private void OnTriggerEnter(Collider other)
    {        
       // other.isTrigger = true;
        other.gameObject.AddComponent<SaniCollideScript>();

            if (other.transform.parent.transform.parent.name == "RightController")
            {
                activeHand = "Right";
            }

            else if (other.transform.parent.transform.parent.name == "LeftController")
            {
                activeHand = "Left";
                /*  if (saniCollider == null)
                  {
                      saniCollider = rightHand.AddComponent<SphereCollider>();
                      saniCollider.isTrigger = true;
                      rightHand.AddComponent<SaniCollideScript>();
                      Debug.Log("Right Hand Collider Created");
                  }*/
            }
        
        Dispense(); 
    }

    private void OnTriggerStay(Collider other)
    {
        dispensing = true;
    }


    private void OnTriggerExit(Collider other)
    {
        dispensing = false;
    }

    public void Dispense() {

        if (!dispensing)
        {
            dispensing = true;
            GameObject thisDollop = Instantiate(sanitizerDollop, dispensePoint.position, Quaternion.identity);


            sanitizerParticles.Play();


            if (activeHand == "Left")
            {
                leftSanitized = true;
                Debug.Log("Left Sani");
            }
            
            if (activeHand == "Right")
            {
                rightSanitized = true;
                Debug.Log("Right Sani");
            }
            thisAudio.clip = dispenseClip;
            thisAudio.Play();
        }
    }

    public void Sanitized()
    {
        thisAudio.clip = contactClip;
        thisAudio.Play();
        if (leftSanitized && rightSanitized)
        {
            Task.CheckTasks(true);
        }
        
       
    }
}
