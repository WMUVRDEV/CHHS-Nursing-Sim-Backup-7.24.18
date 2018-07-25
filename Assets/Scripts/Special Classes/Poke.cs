using System.Collections;
using System.Collections.Generic;
using Obi;
using UnityEngine;
using VRTK;
using UnityEngine.Events;

public class Poke : MonoBehaviour
{
	//public VRTK_InteractableObject_UnityEvents vrtkObject;
	
	
	public UnityEvent PokeEvent;
	public UnityEvent UnpokeEvent;
	public VRTK_InteractTouch touch;
	public GameObject me;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "poke")
		{
			PokeEvent.Invoke();
			Debug.Log(gameObject.name + " " + other.name);
		}
		
		
	//	touch.ForceTouch(me);
	//	touch.IsObjectInteractable(me);
		//	vrtkObject.StartTouching();
		//	vrtkObject.InteractableObjectTouched(other.gameObject);

	}
	
	private void OnTriggerExit(Collider other)
	{
		UnpokeEvent.Invoke();
	}
}
