using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnRDestOff : MonoBehaviour {

    GameObject rightDestPoint;

	// Use this for initialization
	void Start () {
        rightDestPoint = GameObject.Find("Destination Bed Right");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name == "[VRTK][AUTOGEN][RightController][StraightPointRenderer_Tracer]")
        {
            Debug.Log("Hit Left Destination"); 
        }
       // rightDestPoint.SetActive(false);
    }

    void CheckNull(GameObject test)
    {
        if(test == null)
        {
            Debug.Log(test.name + " is null");
            test.SetActive(false);
        }
    }
}
