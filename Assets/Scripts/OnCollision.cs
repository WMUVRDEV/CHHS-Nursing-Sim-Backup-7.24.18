using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class OnCollision : MonoBehaviour
{

	public AudioSource sourceHardColl;
	public AudioSource sourceSoftColl;
	
	public AudioClip hardSurfaceColl;
	public AudioClip softSurfaceColl;

	private float pitchLowPar = .75f;
	private float pitchHighPar = 1.2f;

	private float volume;

	void OnCollisionEnter(Collision coll)
	{
        
       // Debug.Log("Collision Detected");
		sourceHardColl.pitch = Random.Range(pitchLowPar, pitchHighPar);
		volume = coll.relativeVelocity.magnitude * .1f;
		//Debug.Log(coll.gameObject.name);
		//Debug.Log(coll.relativeVelocity.magnitude);

		if (coll.gameObject.tag == "Hard Surface")
		{
			sourceHardColl.pitch = Random.Range(pitchLowPar, pitchHighPar);
			sourceHardColl.PlayOneShot(hardSurfaceColl, volume);
			//Debug.Log("Hard Surface Collision Detected");
		}


		if (coll.gameObject.tag == "Soft Surface")
		{
			sourceSoftColl.pitch = Random.Range(pitchLowPar, pitchHighPar);
			sourceSoftColl.PlayOneShot(softSurfaceColl, volume);
			//Debug.Log("Soft Surface Collision Detected");
		}
	}
}
