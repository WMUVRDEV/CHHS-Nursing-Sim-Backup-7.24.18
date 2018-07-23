using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalineBottle : MonoBehaviour
{
	public Transform parentTrans;
	public GameObject saline;

	public void Pour()
	{
		saline.transform.position = parentTrans.position;
		Instantiate(saline);
		StartCoroutine(Wait());
		Destroy(saline);
		Debug.Log("Saline Used");
	}

	IEnumerator Wait()
	{
		
		yield return new WaitForSeconds(3);
	}
}
