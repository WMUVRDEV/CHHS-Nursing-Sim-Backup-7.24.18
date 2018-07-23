using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskInteractions : MonoBehaviour {

    public Scenario_Transfusion scenarioManager;
    public Task thisTask;
    public int taskNumber;

    public bool maskOn;

    public void MaskInZone()
    {
        maskOn = true;
        thisTask.CheckTasks(true);
    }

    public void MaskOutZone()
    {
        maskOn = false;
    }

}
