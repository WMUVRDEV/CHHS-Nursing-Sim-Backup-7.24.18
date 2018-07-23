namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;

    public class UseThermometer : VRTK_InteractableObject
    {
        Transform rotator;

        public bool tempBeingRead;
        public bool tempIsRead;
        public AudioSource thisAudio;

        public AudioClip grabAudio;
        public AudioClip ungrabAudio;
        
        public AudioClip readAudio;
        public AudioClip completeAudio;

        private float useTime;
        private float startTime;

        public Text temperatureReadout;
        public Scenario_Transfusion scenarioManager;
        public thermometerInteractions thermoManager;
        
       
        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            
            //base.Grabbed(grabbingObject);
        }

        public override void Ungrabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Ungrabbed(grabbingObject);
/*            if (ungrabAudio != null)
            {
                thisAudio.clip = ungrabAudio;
                thisAudio.Play();
            }*/
        }


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
         //   base.StartUsing(usingObject);
         //   thermoManager.ReadTemperature();
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
         //   tempBeingRead = false;
         //   thisAudio.Stop();
        }

        protected override void Update()
        {
            base.Update();

/*            if (tempBeingRead){
                useTime=Time.time-startTime;
                if(useTime>3.0f){
                    tempIsRead = true;
                    thisAudio.Stop();
                    thisAudio.clip = completeAudio;
                    thisAudio.Play();
                    tempBeingRead = false;
                    temperatureReadout.text = "98.6";
                }
            }*/
        }
    }
}