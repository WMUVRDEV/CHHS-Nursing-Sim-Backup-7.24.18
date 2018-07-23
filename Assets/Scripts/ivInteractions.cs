
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.Playables;
    using UnityEngine.Timeline;

   

    public class ivInteractions : MonoBehaviour
    {
        public InputField input;
        public Text testText;
        public AudioSource thisAudio;
        public string correctCode;
	    public AudioClip grabAudio;
        
	    public string currentSpike;
    
        public GameObject TubeA2;
        public GameObject TubeB2;
        public GameObject TubeC;
	    public GameObject TubeD;
        
	    public GameObject hoseSpikeA;
	    public GameObject hoseSpikeB;
	    public GameObject filter;
	    public GameObject hoseFilterToClip;
	    public GameObject hoseClipToLowerClamp;
	    public GameObject hoseLowerClampToSpikeEnd;	
	    
	    public Transform lowerRoller;
	    public Transform lowerRollerOpenLoc;
	    public Transform lowerRollerClosedLoc;
	    
	    public Transform spikeARoller;
	    public Transform spikeARollerOpenLoc;
	    public Transform spikeARollerClosedLoc;
	    
	    public Transform spikeBRoller;
	    public Transform spikeBRollerOpenLoc;
	    public Transform spikeBRollerClosedLoc;
	    
	    public bool lowerClampIsOpen;
	    public bool spikeAClampIsOpen;
	    public bool spikeBClampIsOpen;
	    
        public GameObject bloodHose1;
        public GameObject bloodHose2;
	    public GameObject salineHose1;
	    public GameObject salineHose2;

        public GameObject SpikeA;
        public GameObject SpikeB;
    
        public bool ivAttachedToBlood;
        public bool ivAttachedToSaline;

        public int salineLineClamp;
        public int bloodLineClamp;
       
        public bool bloodSwitchOpen;
        public bool salineSwitchOpen;
       
        public bool ivAttachedtoArm;

        public Material clearTubingMat;
        public Material salineMat;
        public Material bloodMat;

        public bool TubeAFull;
        public bool TubeBFull;
        

        public GameObject sigmaDoor;
        public GameObject sigma;
        public AnimationClip openDoor;
        public Animation doorAnim;
        public Material sigmaScreenMat;
        
        public Text sigmaPowerUpText;
        public Text sigmaLineOne;
        public Text sigmaLineTwo;
        public Text sigmaLineThree;
        public Text sigmaLineFour;
        public Text sigmaFlowAmount;
        public Text sigmaFlowX;
        public Text sigmaFlowY;
        public int currentLineNumber;

	    public string flowNumA;
        public string flowNumB;
	    public string flowNumC;
        
	    public PlayableDirector PB;
	    public List<TimelineAsset> timelines;
	    
	    
	    public bool OnSigmaScreenOne;
	    public bool OnSigmaScreenTwo;
	    public bool ivFlowSelected;
        public bool correctFlowSelected;

        public PlayableDirector SpikeARollerAnim;
        public PlayableDirector SpikeBRollerAnim;
        public PlayableDirector lowerRollerAnim;

        public List<TimelineAsset> rollerAnim;

        public float animTime;
	    

        public bool pageOne;



         public void ClampClosed(string spikeName){
	         //   Debug.Log("Clamp " + spikeName + " Closed");
	         if (spikeName == "LowerClamp"){
		         lowerClampIsOpen = false;
		         hoseLowerClampToSpikeEnd.GetComponent<Renderer>().material = clearTubingMat;
	         }
	         
	         if (spikeName == "SpikeA"){
		         if (bloodHose1 == hoseSpikeA){
		         	bloodSwitchOpen = false;
		         	hoseSpikeA.GetComponent<Renderer>().material = clearTubingMat;
			         filter.GetComponent<Renderer>().material = clearTubingMat;
			         hoseFilterToClip.GetComponent<Renderer>().material = clearTubingMat;
			         hoseClipToLowerClamp.GetComponent<Renderer>().material = clearTubingMat;
		         }
		         if (salineHose1 = hoseSpikeA){
		         	salineSwitchOpen = false;
		         }
	         }
	         
	         if (spikeName == "SpikeB"){
		         if (bloodHose1 == hoseSpikeB){
		         	bloodSwitchOpen = false;
		         	hoseSpikeA.GetComponent<Renderer>().material = clearTubingMat;
			         filter.GetComponent<Renderer>().material = clearTubingMat;
			         hoseFilterToClip.GetComponent<Renderer>().material = clearTubingMat;
			         hoseClipToLowerClamp.GetComponent<Renderer>().material = clearTubingMat;
		         }
		         if (salineHose1 = hoseSpikeB){
		         	salineSwitchOpen = false;
		         }
	         }     
         }
         
	    public void ClampOpen(string spikeName){
		   
		    
		    if (spikeName == "LowerClamp" && !lowerClampIsOpen){
		    	lowerClampIsOpen = true;
			    Debug.Log(spikeName + " opened line 156");
			    if (bloodSwitchOpen){
			    	hoseLowerClampToSpikeEnd.GetComponent<Renderer>().material = bloodMat;
			    	Debug.Log("lower = blood");
			    }
			    else if (salineSwitchOpen){
			    	hoseLowerClampToSpikeEnd.GetComponent<Renderer>().material = salineMat;
			    	Debug.Log("lower = saline");
			    }
			    else {
			    	hoseLowerClampToSpikeEnd.GetComponent<Renderer>().material = clearTubingMat;
			    	Debug.Log("lower = clear");
			    }

                //Opening Lower Roller
                lowerRollerAnim.Play(rollerAnim[0]);

            }
		    else  if (spikeName == "LowerClamp" && lowerClampIsOpen){
		    	lowerClampIsOpen = false;
			    Debug.Log(spikeName + " closed line 162");
			    hoseLowerClampToSpikeEnd.GetComponent<Renderer>().material = clearTubingMat;
                //Closing Lower Roller 
                lowerRollerAnim.Play(rollerAnim[1]);
        }
		    
		   
		    
		    if (spikeName == "SpikeA" && !spikeAClampIsOpen){
			    if (bloodHose1 == hoseSpikeA){
				    hoseSpikeA.GetComponent<Renderer>().material = bloodMat;
				    filter.GetComponent<Renderer>().material = bloodMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = bloodMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = bloodMat;
				    bloodSwitchOpen = true;	
				   
			    }
			    if (salineHose1 == hoseSpikeA){
			    	hoseSpikeA.GetComponent<Renderer>().material = salineMat;
			    	filter.GetComponent<Renderer>().material = salineMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = salineMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = salineMat;
				    salineSwitchOpen = true;	
			    }
                //Open Spike A Roller
                SpikeARollerAnim.Play(rollerAnim[2]);
			    spikeAClampIsOpen = true;
			    Debug.Log(spikeName + " opened line 184"); 
		    }
		    else  if (spikeName == "SpikeA" && !spikeAClampIsOpen){
			    if (bloodHose1 == hoseSpikeA){
				    hoseSpikeA.GetComponent<Renderer>().material = clearTubingMat;
				    filter.GetComponent<Renderer>().material = clearTubingMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = clearTubingMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = clearTubingMat;
				    bloodSwitchOpen = false;
			    }
			    if (salineHose1 = hoseSpikeA){
			    	hoseSpikeA.GetComponent<Renderer>().material = clearTubingMat;
				    filter.GetComponent<Renderer>().material = clearTubingMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = clearTubingMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = clearTubingMat;
				    salineSwitchOpen = false;
			    }
                //Closing Spike A Roller
                SpikeARollerAnim.Play(rollerAnim[3]);
                spikeAClampIsOpen = false;
			    Debug.Log(spikeName + " closed line 202");
		    }
		    
		    
		    
		    if (spikeName == "SpikeB" && !spikeBClampIsOpen){
			    if (bloodHose1 == hoseSpikeB){
				    hoseSpikeB.GetComponent<Renderer>().material = bloodMat;
				    filter.GetComponent<Renderer>().material = bloodMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = bloodMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = bloodMat;
				    bloodSwitchOpen = true;	
				   
			    }
			    if (salineHose1 == hoseSpikeB){
			    	hoseSpikeB.GetComponent<Renderer>().material = salineMat;
			    	filter.GetComponent<Renderer>().material = salineMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = salineMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = salineMat;
				    salineSwitchOpen = true;	
			    }
            //Open Spike B Roller
                SpikeBRollerAnim.Play(rollerAnim[4]);
			    spikeBClampIsOpen = true;
			    Debug.Log(spikeName + " opened line 184"); 
		    }
		    else  if (spikeName == "SpikeB" && !spikeBClampIsOpen){
			    if (bloodHose1 == hoseSpikeB){
				    hoseSpikeB.GetComponent<Renderer>().material = clearTubingMat;
				    filter.GetComponent<Renderer>().material = clearTubingMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = clearTubingMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = clearTubingMat;
				    bloodSwitchOpen = false;
			    }
			    if (salineHose1 = hoseSpikeB){
			    	hoseSpikeB.GetComponent<Renderer>().material = clearTubingMat;
				    filter.GetComponent<Renderer>().material = clearTubingMat;
				    hoseFilterToClip.GetComponent<Renderer>().material = clearTubingMat;
				    hoseClipToLowerClamp.GetComponent<Renderer>().material = clearTubingMat;
				    salineSwitchOpen = false;
			    }
                //Closing spike B roller
                SpikeBRollerAnim.Play(rollerAnim[5]);
			    spikeBClampIsOpen = false;
			    Debug.Log(spikeName + " closed line 202");
		    }
		    

         }

         public void IVAttached(){
	         ivAttachedtoArm = true;
       
    			
	         if (lowerClampIsOpen && bloodSwitchOpen){
		         Debug.Log("IV is open and Flowing"); 	
	         }
            
         }

        public void IVDetached()
        {
            ivAttachedtoArm = false;
        }


    public void operateIV(){
            TubeC.GetComponent<Renderer>().material = bloodMat;
         }

    public void OpenSigmaDoor()
    {
	    PB.Play(timelines[0]);
        sigmaScreenMat.SetColor("_EmissionColor", Color.cyan); //(0.17,0.83,0.86)
	    sigmaPowerUpText.text = ("Do Not set flow until power up is complete");
	    StartCoroutine(SigmaWait(3.0f));
    }

    IEnumerator SigmaWait(float waitTime)
    {
	    yield return new WaitForSeconds(waitTime);
	    OnSigmaScreenOne = true;
	    
	    if (!OnSigmaScreenOne && !OnSigmaScreenTwo){
		    sigmaPowerUpText.text = ("Insert Tubing");
	    }
	    
	    
    }

    public void UpArrow()
	    {
    	 ivFlowSelected = false;
        if (pageOne)
        {
	       
            if (currentLineNumber == 2)
            {
                thisAudio.Play();
                currentLineNumber = 1;
                sigmaLineOne.text = (">>Choice1");
                sigmaLineTwo.text = ("   IV Fluids");
                sigmaLineThree.text = ("   Choice3");
	            sigmaLineFour.text = ("   Choice4");
            }
            else if (currentLineNumber == 3)
            {
                thisAudio.Play();
                currentLineNumber = 2;
                sigmaLineOne.text = ("   Choice1");
                sigmaLineTwo.text = (">>IV Fluids");
                sigmaLineThree.text = ("   Choice3");
	            sigmaLineFour.text = ("   Choice4");
	            ivFlowSelected = true;
            }
            else if (currentLineNumber == 4)
            {
                thisAudio.Play();
                currentLineNumber = 3;
                sigmaLineOne.text = ("   Choice1");
                sigmaLineTwo.text = ("   IV Fluids");
                sigmaLineThree.text = (">>Choice3");
	            sigmaLineFour.text = ("   Choice4");
	           
            }
        }

        else
        {
            if (currentLineNumber == 2)
            {
                thisAudio.Play();
                currentLineNumber = 1;
                sigmaFlowAmount.text = (">>" + flowNumA);
                sigmaFlowX.text = flowNumB;
	            sigmaFlowY.text = flowNumC;
	            correctFlowSelected = false;
            }
            else if (currentLineNumber == 3)
            {
                thisAudio.Play();
                currentLineNumber = 2;
                sigmaFlowAmount.text = flowNumA;
                sigmaFlowX.text = ">>" + flowNumB;
	            sigmaFlowY.text = flowNumC;
	            correctFlowSelected = true;
            }
        }
    }


    public void DownArrow()
	    {
    	 ivFlowSelected = false;
        if (pageOne)
        {
            if (currentLineNumber == 1)
            {
                thisAudio.Play();
                currentLineNumber = 2;
                sigmaLineOne.text = ("   Choice1");
                sigmaLineTwo.text = (">>IV Fluids");
                sigmaLineThree.text = ("   Choice3");
	            sigmaLineFour.text = ("   Choice4");
	            ivFlowSelected = true;
            }


            else if (currentLineNumber == 2)
            {
                thisAudio.Play();
                currentLineNumber = 3;
                sigmaLineOne.text = ("   Choice1");
                sigmaLineTwo.text = ("   IV Fluids");
                sigmaLineThree.text = (">>Choice3");
                sigmaLineFour.text = ("   Choice4");
            }
            else if (currentLineNumber == 3)
            {
                thisAudio.Play();
                currentLineNumber = 4;
                sigmaLineOne.text = ("   Choice1");
                sigmaLineTwo.text = ("   IV Fluids");
                sigmaLineThree.text = ("   Choice3");
                sigmaLineFour.text = (">>Choice4");
            }
        }

        else
        {
            if (currentLineNumber == 1)
            {
                thisAudio.Play();
                currentLineNumber = 2;
                sigmaFlowAmount.text = flowNumA;
                sigmaFlowX.text = ">>"+flowNumB;
	            sigmaFlowY.text = flowNumC;
	            correctFlowSelected = true;
            }


            else if (currentLineNumber == 2)
            {
                thisAudio.Play();
                currentLineNumber = 3;
                sigmaFlowAmount.text = flowNumA;
                sigmaFlowX.text = flowNumB;
                sigmaFlowY.text = ">>" + flowNumC;
	            correctFlowSelected = false;
            }
        }

    }

    public void CloseSigmaDoor()
    {
	    PB.Play(timelines[1]);
        sigmaPowerUpText.text = ("");
        sigmaLineOne.text = (">> Choice1");
        sigmaLineTwo.text = ("   IV Fluids");
        sigmaLineThree.text = ("   Choice3");
        sigmaLineFour.text = ("   Choice4");
	    currentLineNumber = 1;
	    sigmaPowerUpText.text = ("");
    }
    
	    public void Enter()
	    {
	    	
	    	if (OnSigmaScreenOne && ivFlowSelected){
		    	Debug.Log("Enter");
		    	pageOne = false;
		    	thisAudio.Play();
		    	currentLineNumber = 1;
		    	sigmaLineOne.text = ("Flow Rate");
		    	sigmaLineTwo.text = ("");
		    	sigmaLineThree.text = ("");
		    	sigmaLineFour.text = ("");

		    	sigmaFlowAmount.text = ">>" + flowNumA;
		    	sigmaFlowX.text = flowNumB;
		    	sigmaFlowY.text = flowNumC;
		    	OnSigmaScreenTwo = true;
		    	OnSigmaScreenOne = false;
	    	}
	    	
	    	if (correctFlowSelected && OnSigmaScreenTwo){
	    		sigmaLineTwo.text = ("Flow Set to 50mL");
            
	    	}
	    	
		    if (!correctFlowSelected && OnSigmaScreenTwo){
	    		sigmaLineTwo.text = ("Flow Set Wrong");
	    	}
	    
	    
	    }
    
    
	    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
	    public void IdentifySpike (string spike){
	    	currentSpike = spike;
	    }
	    
	    public void UnidentifySpike (){
	    	currentSpike = "";
	    }
    
	    public void SpikeBloodBag(){
	    	Debug.Log(currentSpike + " attached to Blood Bag");
		    if (currentSpike == "SpikeA"){ 
			    bloodHose1=hoseSpikeA;
		    }
		    if (currentSpike == "SpikeB"){ 
			    //hoseSpikeB.GetComponent<Renderer>().material = bloodMat;
			    bloodHose1=hoseSpikeB;
		    } 	
	    }
	    
	    public void SpikeSalineBag(string spikeName){
		    Debug.Log(currentSpike + " attached to Saline Bag");
		    if (currentSpike == "SpikeA"){ 
			    //hoseSpikeA.GetComponent<Renderer>().material = salineMat;
			    salineHose1 = hoseSpikeA;
		    }
		    if (currentSpike == "SpikeB"){ 
			    //hoseSpikeB.GetComponent<Renderer>().material = salineMat;
			    salineHose1 = hoseSpikeB;
		    }
	    }


    public void UnspikedBag(){

         }

	    public void SpikedBag(string spikeName, string bagName){
	    	
            Debug.Log("Bag " + bagName + " Spiked with " + spikeName);
            if (bagName == "BloodBagSnapZone" && spikeName == "SpikeA"){
                bloodHose2 = TubeA2;
                SpikeA.GetComponent<Renderer>().material = bloodMat;
                bloodLineClamp=1;
            }
            else if (bagName == "BloodBagSnapZone" && spikeName == "SpikeB"){
              //bloodHose1 = TubeB1;
                bloodHose2 = TubeB2;
             // bloodHose1.GetComponent<Renderer>().material = bloodMat;
                SpikeB.GetComponent<Renderer>().material = bloodMat;
                bloodLineClamp=2;
            }  
            else if (bagName == "SalineBagSnapZone" && spikeName == "SpikeB"){
              //salineHose1 = TubeB1;
                salineHose2 = TubeB2;
               //salineHose1.GetComponent<Renderer>().material = salineMat;
                SpikeB.GetComponent<Renderer>().material = salineMat;
                 salineLineClamp=2;
            }           
             else if (bagName == "SalineBagSnapZone" && spikeName == "SpikeA"){
              //salineHose1 = TubeA1;
                salineHose2 = TubeA2;
             // salineHose1.GetComponent<Renderer>().material = salineMat;
                SpikeA.GetComponent<Renderer>().material = salineMat;
                salineLineClamp=1;
             // salineHoseC.GetComponent<Renderer>().material = salineMat;
            }
         }

        public void ClickKey(string character)
        {
            thisAudio.Play();
            input.text += character;
            testText.text += character;
        }

        public void Backspace()
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
                testText.text = testText.text.Substring(0, testText.text.Length - 1);
            }
        }
        
     



        private void Start()
        {
                TubeA2.GetComponent<Renderer>().material=clearTubingMat;
                TubeB2.GetComponent<Renderer>().material=clearTubingMat;
                TubeC.GetComponent<Renderer>().material=clearTubingMat;
                sigmaScreenMat.SetColor("_EmissionColor", Color.black); //(0.17,0.83,0.86)
                    sigmaFlowAmount.text = " ";
                    sigmaFlowX.text = " ";
                    sigmaFlowY.text = " ";
      }
    }
