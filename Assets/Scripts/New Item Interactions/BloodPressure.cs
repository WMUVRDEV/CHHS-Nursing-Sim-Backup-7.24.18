using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodPressure : ItemInteraction {

    public Text bloodPressureDisplay;
    public Material screenMat;

    public AudioClip powerOnClip;
    
    public int systolic;
    public int diastolic;
    public bool bpCuffAttached;
    public bool bpIsRead;
    
    public GameObject BPCuffMain;
    public GameObject BPCuffWrapped;
    private GameObject tipOfPointerFinger;
    
    public bool machineReady;
    public bool bpReadingInProgress;
    public int powerDownWaitTime;
	    
    public Labeling BPMachineLabel;

    public OvrAvatar avatar;
    public GameObject rightHandPointerPose;

    public void DontRun()
    {    
        avatar.RightHandCustomPose = rightHandPointerPose.transform;
        Debug.Log("In Pointer Zone");
         
        if (rightHandPointerPose == null){Debug.Log("Custom Hand Is Null");}

        if (avatar.RightHandCustomPose != null) {Debug.Log("Right Hand Present");}

        if (GameObject.Find("hands:b_r_index_ignore") != null)
        {
            Debug.Log("Index Finger Found");
            tipOfPointerFinger = GameObject.Find("hands:b_r_index_ignore");
            tipOfPointerFinger.AddComponent<BoxCollider>().size = new Vector3(.05f,.04f,.02f);
            tipOfPointerFinger.AddComponent<Rigidbody>().isKinematic = true;
            tipOfPointerFinger.GetComponent<Rigidbody>().useGravity = false;

        }
        else if (GameObject.Find("hands:b_r_index_ignore") == null)
        {
            Debug.Log("Index Finger Not Found");
            
        }

       // StartCoroutine(WaitTime());
    }

    public void DontRunExit()
    {
        avatar.RightHandCustomPose = null;
        Destroy(tipOfPointerFinger.GetComponent<BoxCollider>());
        Destroy(tipOfPointerFinger.GetComponent<Rigidbody>());
    }
    
    void Start()
    {
        screenMat.SetColor("_EmissionColor", Color.black); 
    }
    
    public void BPCuffAttached()
    {
        BPCuffWrapped.SetActive(true);
        BPCuffMain.SetActive(false);
        bpCuffAttached = true;
    }
    
    public void PowerBPMachine()
    {
        
        Debug.Log("PowerBPMachine");
    	
        if (!machineReady){
            screenMat.SetColor("_EmissionColor", Color.cyan); //(0.17,0.83,0.86)
            bloodPressureDisplay.text = "Starting";
            StartCoroutine(BpReady());
        }
/*        else{
            screenMat.SetColor("_EmissionColor", Color.black); 
            bloodPressureDisplay.text = "";
        }*/
		    
        if (BPMachineLabel !=null){
            BPMachineLabel.labeledObjectGrabbed = true;
        } 
    }
    
    IEnumerator BpReady()
    {
        thisAudio.clip = powerOnClip;
        thisAudio.Play();
        yield return new WaitForSeconds(1);
        bloodPressureDisplay.text = "Ready";
        machineReady = true;
        StartCoroutine(PowerDown());
    }
    
    
    
    public void StartBPMachine()
    {
        thisAudio.Play();
        if (bpCuffAttached){
            bloodPressureDisplay.text = "Reading...";
            thisAudio.Play();
            StartCoroutine(ReadBloodPressure());
        }
            
        // what do we do if the cuff is not attached
    }
    
    public void BPCuffRemoved(){
        if (!bpIsRead){
            bpCuffAttached = false;
            thisAudio.Stop();
            bloodPressureDisplay.text = ("0/0");
        }
        BPCuffWrapped.SetActive(false);
        BPCuffMain.SetActive(true);
    }
    
    void RestartTimer(){
        StartCoroutine(PowerDown());
    }
    
   
    IEnumerator ReadBloodPressure()
    {
    	
        bpReadingInProgress = true;

        yield return new WaitForSeconds(5);
       
        systolic = (Random.Range(100, 200));
        diastolic = (Random.Range(50, 99));
    
        if (bpCuffAttached){
            bloodPressureDisplay.text = ("" + systolic + "/" + diastolic);
            bpReadingInProgress = false;
          //  scenarioManager.bpIsRead = true;
            Task.CheckTasks(true);
        }
        else{
            bloodPressureDisplay.text = ("0/0");
        }
        thisAudio.Stop();
    }

    IEnumerator PowerDown()
    {

        yield return new WaitForSeconds(powerDownWaitTime);
    
        if (bpReadingInProgress){
            RestartTimer();
        }
        else{
            screenMat.SetColor("_EmissionColor", Color.black); //(0.17,0.83,0.86)
            bloodPressureDisplay.text = "";
            machineReady = false;
            bpReadingInProgress = false;
        }
		 
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3);
    }
}
