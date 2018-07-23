using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class wristReturn : MonoBehaviour
{


	public Transform wristStart;
	
	
	
	void Start ()
	{
	//	wristStart = gameObject.transform;
	}
	
	// Update is called once per frame
	public void ReturnWrist ()
	{

		Debug.Log("return");
		transform.position = wristStart.transform.position;
		transform.rotation = wristStart.transform.rotation;

	}
}
