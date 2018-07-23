using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanitizerDollop : MonoBehaviour {

    public SanitizerInteractions Sanitizer;


	void OnTiggerEnter (Collider collider) {
        Sanitizer = GameObject.Find("SanitizerInteractions").GetComponent<SanitizerInteractions>();

        Debug.Log("dollop hit " + collider.name);

        if (collider.name == "hand_right_renderPart_0")
        {

        }
        Destroy(gameObject, 1.0f);
	}

}
