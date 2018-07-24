using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParentObject : MonoBehaviour {

    public Transform myParent;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (myParent != null)
        {
            transform.position = myParent.transform.position;
        }
    }
}
