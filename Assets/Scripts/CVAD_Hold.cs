using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVAD_Hold : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider collider) {
        Debug.Log(collider.name);
		
	}
}
