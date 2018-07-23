using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BpBlend : MonoBehaviour {


	private float foldedAmount = 0.0f;
	private float wrappedAmount = 0.0f;
	public float wrapSpeed = 0.01f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("FoldToWrap", 0.0f, wrapSpeed);
	}
	
	// Update is called once per frame
	void FoldToWrap () {
		
		if (wrappedAmount >100.0f){
			CancelInvoke("FoldToWrap");
		}
		
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(1, wrappedAmount++);
		GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, foldedAmount--);
	}
}
