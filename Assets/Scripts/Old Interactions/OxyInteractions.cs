
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
using System.Collections.Generic;

    public class OxyInteractions : MonoBehaviour
    {
       
        
        
        public Text testText;
	    public AudioSource thisAudio;
        public AudioClip readingClip;
        public AudioClip readClip;
        public AudioClip grabAudio;


        public bool oxyBeingRead;
        public bool oxyIsRead;
        public bool inSnapZone;

        public Task thisTask;
        public int taskNumber;
      //  public Scenario_Transfusion scenarioManager;


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
        testText.text = ("-");
        yield return new WaitForSeconds(0.66f);
        testText.text = ("- -");
        yield return new WaitForSeconds(0.66f);
        testText.text = ("- - -");
        yield return new WaitForSeconds(0.66f);
        thisAudio.clip = readClip;
        thisAudio.Play();


            if (oxyBeingRead)  {
                oxyBeingRead = false;
                testText.text = ("OxyLVL 99%");
                oxyIsRead = true;
                thisTask.CheckTasks(true);
                 yield return new WaitForSeconds(2);
                testText.text = (". . .");
        }

        else
        {
            testText.text = ("NO READ");
          //  Scenario_Transfusion.tempIsRead = true;
            oxyIsRead = true;
            yield return new WaitForSeconds(2);
            testText.text = (". . .");
        }
    }


    }
