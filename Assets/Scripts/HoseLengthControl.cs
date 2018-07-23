using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoseLengthControl : MonoBehaviour {

    public Transform stethArms, stethEnd;
    public Rigidbody stethEndRB;
   
    public float distanceLimit;

    public float distance;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(stethArms.position, stethEnd.position);
        //Debug.Log(distance);



        if (distance > distanceLimit)
        {
            stethEndRB.useGravity = false;
        }

    }
}
