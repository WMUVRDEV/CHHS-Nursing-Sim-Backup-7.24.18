using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBag : ItemInteraction {

    public Canvas bloodAdminCanvas;

    void Start()
    {
        bloodAdminCanvas.enabled = false;
    }

    public override void Grabbed()
    {
        base.Grabbed();
        bloodAdminCanvas.enabled = true;
        StartCoroutine(BloodBagWait());
    }


    IEnumerator BloodBagWait()
    {
        yield return new WaitForSeconds(5.0f);
        bloodAdminCanvas.enabled = false;
        Task.CheckTasks(true);
    }

}
