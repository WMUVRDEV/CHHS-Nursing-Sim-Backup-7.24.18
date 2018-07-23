using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FocalPoint : MonoBehaviour {

	
	public Transform target;
	public GameObject vrCamera;
	
	
	public	void RotateToFocalPoint () {
		vrCamera.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
	}
}



