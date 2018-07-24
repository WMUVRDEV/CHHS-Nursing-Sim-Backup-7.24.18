using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wristband : ItemInteraction {
	
	public AudioClip nurseClip;
	public AudioClip patientClip;

	public bool wristbandBeingRead;
	public bool wristbandIsRead;

	public Transform wristReturn;

    public Canvas wristbandCanvas;

     void Start()
    {
        wristbandCanvas.enabled = false;
    }

    public override void Grabbed()
	{
        wristbandCanvas.enabled = true;
        StartCoroutine(ReadWrist());
        
	}
	
	IEnumerator ReadWrist()
	{
        yield return new WaitForSeconds(8.5f);
        wristbandCanvas.enabled = false;

        //       thisAudio.clip = nurseClip;
        //       //thisAudio.Play();
        //       yield return new WaitForSeconds(3.5f);
        //       thisAudio.Stop();
        //       thisAudio.clip = patientClip;
        //       //thisAudio.Play();
        //       yield return new WaitForSeconds(3.5f);
        //       thisAudio.Stop();
        Task.CheckTasks(true);
	}

}
