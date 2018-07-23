using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatLabel : MonoBehaviour
{
	private LineRenderer lineRenderer;
	private float counter;
	private float dist;

	public Transform targetA;
	public Transform targetB;
	public float lineDrawSpeed = 6f;
	public Transform target;


	// Use this for initialization
	void Start()
	{
		targetA = transform;
		targetB = gameObject.transform.parent;
		
		lineRenderer = GetComponent<LineRenderer>();
	//	lineRenderer.SetPosition(0, targetA.position);
	//	lineRenderer.SetWidth(.45f, .45f);
		dist = Vector3.Distance(targetA.position, targetB.position);
		//lineRenderer.endWidth 
	}

	void Update()
	{

	transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);


			if (counter < dist)
			{
				counter += .1f / lineDrawSpeed;
				float x = Mathf.Lerp(0, dist, counter);
				Vector3 pointA = targetA.position;
				Vector3 pointB = targetB.position;
				//Get the Univer vector in desired direct, multiply by the desired length, and add the starting point.
				//Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
				lineRenderer.SetPosition(0, pointA);
				lineRenderer.SetPosition(1, pointB);
			}
		}
	}


