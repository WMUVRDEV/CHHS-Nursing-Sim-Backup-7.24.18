using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTriggers : MonoBehaviour {

 
	public AudioSource AS;
	public AudioClip NurseBP;
	public AudioClip NurseOxygen;
	public AudioClip NurseSteth, NurseBeforeWeBegin, NurseTellMeYourName,NurseThermo, PatientMhmm, PatientMyName, PatientOK, PatientIFilledItOut;
	
	bool played, played1, played2, played3, played4, played5, played6, played7, played8,played9 = false;
	public TriggerIAlreadyFilledOut ClipboardTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void NurseBPInteraction(){
		if(played == false){
			AS.PlayOneShot(NurseBP);
			played = true;
		}
	}
	
	public void NurseOxygenInteraction(){
		if(played1 == false){
			AS.PlayOneShot(NurseOxygen);
			played1 = true;
		}
	}
	
	public void NurseStethInteraction(){
		if(played2 == false){
			AS.PlayOneShot(NurseSteth);
			played2 = true;
		}
	}
	
	public void NurseBeforeWeBeginInteraction(){
		if(played3 == false){
			AS.PlayOneShot(NurseBeforeWeBegin);
			played3 = true;
		}
	}
	
	public void NurseTellMeYourNameInteraction(){
		if(played4 == false){
			AS.PlayOneShot(NurseTellMeYourName);
			played4 = true;
		}
	}
	
	public void NurseThermoInteraction(){
		if(played5 == false){
			AS.PlayOneShot(NurseThermo);
			played5 = true;
		}
	}
	
	public void PatientMhmmInteraction(){
		if(played6 == false){
			AS.PlayOneShot(PatientMhmm);
			played6 = true;
		}
	}
	
	public void PatientMyNameInteraction(){
		if(played7 == false){
			AS.PlayOneShot(PatientMyName);
			played7 = true;
		}
	}
	
	public void PatientOKInteraction(){
		if(played8 == false){
			AS.PlayOneShot(PatientOK);
			played8 = true;
		}
	}
	
	public void PatientFilledItOutInteraction(){
		played9 = ClipboardTrigger.ClipBoardSigned;
		if(played9 == true){
			AS.PlayOneShot(PatientIFilledItOut);;
		}
	}
	
}
