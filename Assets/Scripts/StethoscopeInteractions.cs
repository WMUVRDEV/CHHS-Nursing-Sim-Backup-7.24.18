using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class StethoscopeInteractions : MonoBehaviour
{

    public AudioClip goodHeart, badHeart, goodBreath, badBreath, 
           grabAudio;

    public bool isBadReading;

    public AudioSource heartbeat, breathing;

    public bool stethEndInZone, stethArmsInZone, stethWorking, stethComplete;

    public int stethTime;

    public Task thisTask;
    public int taskNumber;
    public Scenario_Transfusion scenarioManager;

    public VRTK_InteractableObject stethEnd;

    void Start()
    {
	      stethEnd.isGrabbable = false;
    }
     
    public void CheckSnap (GameObject whichEnd)
    {
        Debug.Log(whichEnd.name);


        if (whichEnd.tag == "StethoArms")
        {
            stethEnd.isGrabbable = true;
	        Debug.Log("Stetho Arms Attached XXX");
        }
        else if (whichEnd.tag == "stetho")
        {
            Debug.Log("Stetho End Attached ");
            stethWorking = true;
            UsingStethoscope();
        }
    


    }

	public void UnsnapEnd()
    {
        //if (heartbeat.time > stethTime)
        //{
        //    stethComplete = true;
        //}
 
  
            stethWorking = false;
	        //  stethComplete = false;
            heartbeat.Stop();
            breathing.Stop();
        
    }
    
	public void UnsnapArms()
	{
		//if (heartbeat.time > stethTime)
		//{
		//	stethComplete = true;
		//}
		
			stethWorking = false;
			//		stethComplete = false;
			heartbeat.Stop();
			breathing.Stop();
			stethEnd.isGrabbable = false;

	}



	void UsingStethoscope() {		
		heartbeat.clip = goodHeart;
		breathing.clip = goodBreath;
		
		heartbeat.Play();
		breathing.Play();
        
        
		StartCoroutine(StethTimer());
        


	}
    
	IEnumerator StethTimer(){
		while (heartbeat.time < stethTime){
		
			yield return null;
		}
		
		if (stethWorking){
			stethComplete = true;
			thisTask.CheckTasks(true);
			heartbeat.Stop();
			breathing.Stop();
			heartbeat.clip =grabAudio;
			heartbeat.Play();
		}
	}

}
