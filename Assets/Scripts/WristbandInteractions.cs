
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
using System.Collections.Generic;

    public class WristbandInteractions : MonoBehaviour
    {
        public Text testText;
        public AudioSource thisAudio;
        public AudioClip nurseClip;
        public AudioClip patientClip;

        public bool wristbandBeingRead;
        public bool wristbandIsRead;

        public Task thisTask;
        public int taskNumber;
        public Scenario_Transfusion scenarioManager;

        public Transform wristReturn;


    public void ReadWristband()
    {
        StartCoroutine(ReadWrist());
    }

    IEnumerator ReadWrist()
    {
       
        thisAudio.clip = nurseClip;
        thisAudio.Play();
        yield return new WaitForSeconds(3.5f);
        thisAudio.Stop();
        thisAudio.clip = patientClip;
        thisAudio.Play();
        yield return new WaitForSeconds(3.5f);
        thisAudio.Stop();
        thisTask.CheckTasks(true);
    }



}
