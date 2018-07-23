using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Labeling : MonoBehaviour

{
	public GameObject myLabel;
	public bool labeledObjectGrabbed;
	

	void Start()
	{
		myLabel.SetActive(false);
	}
	
	public void grabbed (){
		labeledObjectGrabbed = true;
		myLabel.SetActive(false);
		//Debug.Log("grabbed");
	}

	public void ShowLabel()
	{
		if(!labeledObjectGrabbed){
			myLabel.SetActive(true);
		}
	}

	public void HideLabel()
	{
		myLabel.SetActive(false);
	}
}
