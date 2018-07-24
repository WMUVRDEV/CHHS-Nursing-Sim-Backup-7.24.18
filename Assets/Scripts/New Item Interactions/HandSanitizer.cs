using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication;
using Obi;
using UnityEngine;

public class HandSanitizer : ItemInteraction
{

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

    public GameObject colliderCube;
    private GameObject newCCube;
    public ParticleSystem sanitizerParticles;

    public override void Grabbed()
    {
        base.Grabbed();
    }




    private void OnTriggerEnter(Collider other)
    {
        // other.isTrigger = true;


        //Debug.Log(other.gameObject.name);

        if (other.gameObject.name == "Sphere")
        {
            ParticleSystem.CollisionModule pCollision = sanitizerParticles.collision;
            newCCube = Instantiate(colliderCube);
            newCCube.GetComponent<FollowParentObject>().myParent = other.transform;
            pCollision.SetPlane(0, newCCube.transform);

        }

        //if (other.gameObject.GetComponent<SaniCollideScript>() == null)
        //{
        //    other.gameObject.AddComponent<SaniCollideScript>();
        //}

        if (other.transform.parent.transform.parent.name == "RightController")
        {
            activeHand = "Right";
            Dispense();
        }

        else if (other.transform.parent.transform.parent.name == "LeftController")
        {
            activeHand = "Left";
            Dispense();

        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        // dispensing = true;
    }


    private void OnTriggerExit(Collider other)
    {
        dispensing = false;
        sanitizerParticles.Stop();
        if (newCCube != null)
        {
            Destroy(newCCube);
        }
    }

    public void Dispense()
    {

        if (!dispensing)
        {
            dispensing = true;
        //    GameObject thisDollop = Instantiate(sanitizerDollop, dispensePoint.position, Quaternion.identity);

            sanitizerParticles.Play();

            if (activeHand == "Left")
            {
                leftSanitized = true;
                Debug.Log("Left Sani");
                if (leftSanitized && rightSanitized)
                {
                    Sanitized();
                }
            }

            if (activeHand == "Right")
            {
                rightSanitized = true;
                Debug.Log("Right Sani");
                if (leftSanitized && rightSanitized)
                {
                    Sanitized();
                }
            }

            thisAudio.clip = dispenseClip;
            thisAudio.Play();
        }
    }

    public void Sanitized()
    {
        thisAudio.clip = contactClip;
        thisAudio.Play();
        Debug.Log("both Sani");
        if (leftSanitized && rightSanitized)
        {
            Task.CheckTasks(true);
        }


    }
}
