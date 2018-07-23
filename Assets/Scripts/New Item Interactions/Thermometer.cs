using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thermometer : ItemInteraction {

    public Text thermometerDisplayText;
   
    public AudioClip readingClip;
    public AudioClip readClip;
    public AudioClip  completeClip;


    public bool tempBeingRead;
    public bool tempIsRead;
    
    public bool inSnapZone;
    
    private float useTime;
    private float startTime;


    public void ReadTemperature()
    {
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

    
    public override void UnUse()
    {
        tempBeingRead = false;
        thisAudio.Stop();
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
        thermometerDisplayText.text = ("-");
        yield return new WaitForSeconds(0.66f);
        thermometerDisplayText.text = ("- -");
        yield return new WaitForSeconds(0.66f);
        thermometerDisplayText.text = ("- - -");
        yield return new WaitForSeconds(0.66f);
        thisAudio.clip = readClip;
        thisAudio.Play();

        if (tempBeingRead){
            tempBeingRead = false;
            thermometerDisplayText.text = ("Temp 98.5f");
            tempIsRead = true;
            Task.CheckTasks(true);
            yield return new WaitForSeconds(5);
            thermometerDisplayText.text = (". . .");
        }

        else
        {
            tempBeingRead = false;
            thermometerDisplayText.text = ("NO READ");
            tempIsRead = true;
            yield return new WaitForSeconds(5);
            thermometerDisplayText.text = (". . .");
        }
    }


}
