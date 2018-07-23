using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SpikeDistance : MonoBehaviour {

    public Transform spikeEnd;
    public float maxDistance;
    public float actualDistance;

    public VRTK_InteractableObject grabber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        actualDistance = Vector3.Distance(gameObject.transform.position, spikeEnd.position);

        
        if (actualDistance > maxDistance)
        {
            spikeEnd.position = spikeEnd.position + (gameObject.transform.position - spikeEnd.position)/2;
            grabber.Ungrabbed(gameObject);


        }

    }




   // function restrinctPos(posStart, Vector2, newPos:Vector2)
   // {

   //     var posRestrinct:Vector2;

      //  distance = Vector2.Distance(posStart, newPos);
     //   if (distance > maxDistance) distance = maxDistance;

     //   posRestrinct = posStart + (newPos - posStart).normalized * distance;

        //return posRestrinct;
   // }






}
