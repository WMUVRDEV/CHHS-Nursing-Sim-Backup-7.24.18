using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenReader : ItemInteraction {

    
    public Text oxyDisplayText;
    public AudioClip readingClip;
    public AudioClip readClip;
    
    public bool oxyBeingRead;
    public bool oxyIsRead;

    public override void Grabbed()
    {
        base.Grabbed();
    }
    
    public override void Ungrabbed()
    {
        base.Ungrabbed();
    }
    
    
    public void ReadOxy()
    {
        thisAudio.clip = readingClip;
        StartCoroutine(ReadingOxy());
        oxyBeingRead = true;
    }

    public void OxyRemoved(){
        oxyBeingRead = false;
    }


    IEnumerator ReadingOxy()
    {
        thisAudio.Play();
        oxyDisplayText.text = ("-");
        yield return new WaitForSeconds(0.66f);
        oxyDisplayText.text = ("- -");
        yield return new WaitForSeconds(0.66f);
        oxyDisplayText.text = ("- - -");
        yield return new WaitForSeconds(0.66f);
        thisAudio.clip = readClip;
        thisAudio.Play();


        if (oxyBeingRead)  {
            oxyBeingRead = false;
            oxyDisplayText.text = ("OxyLVL 99%");
            oxyIsRead = true;
            Task.isComplete = true;
            Task.CheckTasks(true);
            yield return new WaitForSeconds(5);
            oxyDisplayText.text = (". . .");
        }

        else
        {
            oxyDisplayText.text = ("NO READ");
            oxyIsRead = true;
            yield return new WaitForSeconds(5);
            oxyDisplayText.text = (". . .");
        }
    }

    
}
