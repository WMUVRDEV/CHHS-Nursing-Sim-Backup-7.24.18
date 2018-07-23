using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wristband : ItemInteraction {
	
	//public ItemInteraction interaction = new ItemInteraction(); 
	//public xTask Task = new xTask();
	
	
	public AudioClip nurseClip;
	public AudioClip patientClip;

	public bool wristbandBeingRead;
	public bool wristbandIsRead;

	public Transform wristReturn;
	
	
	public override void Grabbed()
	{
		StartCoroutine(ReadWrist());
	}
	
	IEnumerator ReadWrist()
	{  
		thisAudio.clip = nurseClip;
		//thisAudio.Play();
		yield return new WaitForSeconds(3.5f);
		thisAudio.Stop();
		thisAudio.clip = patientClip;
		//thisAudio.Play();
		yield return new WaitForSeconds(3.5f);
		thisAudio.Stop();
		Task.CheckTasks(true);
	}

}
