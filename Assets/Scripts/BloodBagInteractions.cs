
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
	using System.Collections.Generic;

    public class BloodBagInteractions : ItemInteraction
    {
        
        public GameObject AsstNurse;

        public bool bloodCheckComplete;


    void Start()
    {
        AsstNurse.SetActive(false);
    }

    public void IsGrabbed()
    {
        if (!bloodCheckComplete)
        {
            AsstNurse.SetActive(true);
            thisAudio.Play();
            bloodCheckComplete = true;
        }
    }
        






}
