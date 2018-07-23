
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
using System.Collections.Generic;
    using JetBrains.Annotations;

public class thermometerInteractions : MonoBehaviour
    {
    
        public Text testText;
        public AudioSource thisAudio;
   
        public AudioClip readingClip;
        public AudioClip readClip;

        public bool tempBeingRead;
        public bool tempIsRead;
        public bool inSnapZone;

        public Task thisTask;
        public int taskNumber;
      


        public void ReadTemperature()
        {

        //testText.text = ("- - -");
        Debug.Log("insnapzone: " + inSnapZone);
                if (inSnapZone){
                    tempBeingRead = true;
                    thisAudio.clip = readingClip;   
                    StartCoroutine(ReadTemp());
                }

        else
        {
            thisAudio.clip = readingClip;
            StartCoroutine(ReadTemp());
            tempBeingRead = false;
        }
    }
        


    public void ThermoInSnapZone()
    {
        inSnapZone = true;
    }

    public void ThermoRemoved(){
              inSnapZone = false;
              tempBeingRead = false;
        }



         IEnumerator ReadTemp()
    {
        thisAudio.Play();
        testText.text = ("-");
        yield return new WaitForSeconds(0.66f);
        testText.text = ("- -");
        yield return new WaitForSeconds(0.66f);
        testText.text = ("- - -");
        yield return new WaitForSeconds(0.66f);
        thisAudio.clip = readClip;
        thisAudio.Play();




            if (tempBeingRead){
                tempBeingRead = false;
                testText.text = ("Temp 98.5f");
                //Scenario_Transfusion.tempIsRead = true;
                tempIsRead = true;
                thisTask.CheckTasks(true);
	            yield return new WaitForSeconds(5);
                testText.text = (". . .");
        }

        else
        {
            tempBeingRead = false;
            testText.text = ("NO READ");
          //  Scenario_Transfusion.tempIsRead = true;
            tempIsRead = true;
	        yield return new WaitForSeconds(5);
            testText.text = (". . .");
        }
    }


    }
