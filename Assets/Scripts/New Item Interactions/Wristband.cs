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

  public  void clickedButton()
    {
        wristbandCanvas.enabled = false;
        Task.CheckTasks(true);
    }
	
	IEnumerator ReadWrist()
	{
        yield return new WaitForSeconds(20.0f);
        wristbandCanvas.enabled = false;
        Task.CheckTasks(true);
	}

}
