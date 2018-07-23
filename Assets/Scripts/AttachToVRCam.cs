using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToVRCam : MonoBehaviour
{

	public Transform attachPoint;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void Attach ()
	{
		transform.position = attachPoint.position;
		transform.parent = attachPoint;
		Debug.Log("Attaching");

	}
}
