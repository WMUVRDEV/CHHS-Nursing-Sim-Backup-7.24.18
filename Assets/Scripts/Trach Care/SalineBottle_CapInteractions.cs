 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.AI;
 using UnityEngine.Events;
 using VRTK;
 using VRTK.UnityEventHelper;

public class SalineBottle_CapInteractions : MonoBehaviour
{
	private GameObject salineCap;
	private GameObject salineCapSnapZone;
	private GameObject protSeal;
	private GameObject salineBottle;
	
	

	private bool capSnapped = true;
	private bool enableProtSeal = false;
	private bool eventListOnOff = true;

	public void BottleGrabbed()
	{
		salineCap.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
		salineCapSnapZone.SetActive(true);
		Debug.Log("Bottle Has Been Grabbed");
	}

	public void BottleUngrabbed()
	{
		if (capSnapped)
		{
			salineCap.GetComponent<VRTK_InteractableObject>().isGrabbable = false;
			Debug.Log("Cap is on Bottle, and Bottle is ungrabbed");
		}
		
		else if (!capSnapped)
		{
			Debug.Log("Cap is not on bottle!");
		}
	}

	public void CapOnBottle()
	{
		capSnapped = true;
		salineCap.GetComponent<Rigidbody>().isKinematic = true;
		salineCap.GetComponent<Rigidbody>().useGravity = false;
		salineCap.transform.parent = salineBottle.transform;
		Debug.Log("Cap is on Bottle");
	}

	public void CapGrabbed()
	{
		capSnapped = false;
		salineCap.GetComponent<Rigidbody>().isKinematic = false;
		salineCap.GetComponent<Rigidbody>().useGravity = true;
		salineCap.transform.SetParent(null);
		if(eventListOnOff == true){enableProtSeal = true;}
		Debug.Log("Cap is Grabbed");
		
	}

	public void CapUngrabbed()
	{
		salineCap.GetComponent<Rigidbody>().useGravity = true;
		salineCap.GetComponent<Rigidbody>().isKinematic = false;
		salineCap.transform.SetParent(null);
		capSnapped = true;
	}

	public void ProtectiveSealActive()
	{
		
		Debug.Log(enableProtSeal); 
		if (enableProtSeal == true)
		{
			protSeal.GetComponent<BoxCollider>().enabled = true;
			protSeal.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
			Debug.Log("Protective Seal Is Active");
			eventListOnOff = false;
		}
		
		else if(enableProtSeal== false){Debug.Log("Protective Seal Not Active");}
	}

	public void ProtSealGrabbed()
	{
		protSeal.GetComponent<Rigidbody>().useGravity = true;
		protSeal.GetComponent<Rigidbody>().isKinematic = false;
		protSeal.transform.SetParent(null);
		
	}

	public void PrtoSealUngrabbed()
	{
		protSeal.GetComponent<Rigidbody>().useGravity = true;
		protSeal.GetComponent<Rigidbody>().isKinematic = false;
		protSeal.transform.SetParent(null);
	}

	void CannotFindGameObject(GameObject testObject)
	{
		if (testObject == null)
		{
			Debug.Log("Cannot find " + testObject.name);
			testObject = null;
		}
	}
	
	// Use this for initialization
	void Start () {
		salineCap = GameObject.Find("Cap");
		salineCapSnapZone = GameObject.Find("Saline_CapSnapZone");
		protSeal = GameObject.Find("ProtectiveSeal");
		protSeal.GetComponent<BoxCollider>().enabled = false;
		salineBottle = GameObject.Find("SalineBottle");
		
		CannotFindGameObject(salineCap);
		CannotFindGameObject(salineCapSnapZone);
		CannotFindGameObject(protSeal);
		CannotFindGameObject(salineBottle);
		
		
	}
	
	
}
