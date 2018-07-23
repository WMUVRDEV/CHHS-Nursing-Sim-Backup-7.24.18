
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
using System.Collections.Generic;

    public class bpInteractions : MonoBehaviour
    {
        public InputField input;
        public Text bpText;
        public AudioSource thisAudio;
        public Material screenMat;
        public AudioClip grabAudio;
        

        public int systolic;
        public int diastolic;
        public bool bpCuffAttached;
        public bool bpIsRead;

        public Scenario_Transfusion scenarioManager;
        public Task thisTask;
        public int taskNumber;

		public GameObject BPCuffMain;
	    public GameObject BPCuffWrapped;
    
	    public bool machineReady;
	    public bool bpReadingInProgress;
	    public int powerDownWaitTime;
	    
	    public Labeling BPMachineLabel;

    void Start()
    {
       // bpText.text = " ";
        screenMat.SetColor("_EmissionColor", Color.black); 
    }
     
  
        
    public void BPCuffAttached()
    {
        BPCuffWrapped.SetActive(true);
        BPCuffMain.SetActive(false);
        bpCuffAttached = true;
       // StartBPMachine();
    }


    public void PowerBPMachine()
	    {
    	
		    if (!machineReady){
			      screenMat.SetColor("_EmissionColor", Color.cyan); //(0.17,0.83,0.86)
			    bpText.text = "Starting";
			    StartCoroutine(BpReady());
		    }
		    else{
		    	screenMat.SetColor("_EmissionColor", Color.black); 
			    bpText.text = "";
		    }
		    
		    if (BPMachineLabel !=null){
		    	BPMachineLabel.labeledObjectGrabbed = true;
		    }
        
    }

    public void StartBPMachine()
        {

        thisAudio.Play();
        if (bpCuffAttached){
            bpText.text = "Reading...";
                thisAudio.Play();
                StartCoroutine(ReadBloodPressure());
        }
            
	        // what do we do if the cuff is not attached
        }
        
        
        
	    IEnumerator BpReady()
	    {
		    yield return new WaitForSeconds(3);
		    bpText.text = "Ready";
		    machineReady = true;
		    StartCoroutine(PowerDown());
	    }



        public void BPCuffRemoved(){
            if (!bpIsRead){
                bpCuffAttached = false;
                thisAudio.Stop();
        		bpText.text = ("0/0");
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
            bpText.text = ("" + systolic + "/" + diastolic);
            bpReadingInProgress = false;
            scenarioManager.bpIsRead = true;
	           thisTask.CheckTasks(true);
        }
                else{
            bpText.text = ("0/0");
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
			    bpText.text = "";
			    machineReady = false;
			    bpReadingInProgress = false;
		    }
		 
	    }


    }
