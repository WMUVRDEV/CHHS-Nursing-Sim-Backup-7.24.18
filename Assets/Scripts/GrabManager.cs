using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabManager : MonoBehaviour {

    public BloodBagInteractions bloodBagSystem;

	// Use this for initialization
	public void GrabBloodBag()
    {

        //if grabbed object = blood bag
        bloodBagSystem.IsGrabbed();
    }
}
