using UnityEngine;
using System.Collections;
using NewtonVR;
using UnityEngine.UI;

namespace NewtonVR.Example
{
    public class FlowButton : MonoBehaviour
    {
       // public NVRButton Button;

        public GameObject ToCopy;

        public Text outputText;

        public string changeText;

        public AudioSource thisAudio;

        private void OnTriggerEnter(){
            thisAudio.Play();
            outputText.text = changeText;
        }

         private void OnTriggerExit(){
            thisAudio.Stop();
        }

        private void Update()
        {
 
        }
    }
}