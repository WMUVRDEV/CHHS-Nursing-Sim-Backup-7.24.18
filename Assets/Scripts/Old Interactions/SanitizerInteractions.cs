using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SanitizerInteractions : MonoBehaviour
{

    public AudioSource sanSound;

    public GameObject sanitizerDollop;
    public Transform dispensePoint;

    public TaskManager thisTaskGroup;
    public Task thisTask;
    public int taskNumber;
    public Scenario_Transfusion scenarioManager;

    public GameObject thisDollop;
	public SanitizerDollop sanDollopScript;


   public void Dispense() {
     thisDollop = Instantiate(sanitizerDollop, dispensePoint.position, Quaternion.identity);
    }

    public void Sanitized()
    {
        thisTask.CheckTasks(true);
    }


}
