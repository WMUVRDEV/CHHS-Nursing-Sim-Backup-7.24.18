namespace VRTK.Examples
{
    using UnityEngine;

    public class GrabIVSite : VRTK_InteractableObject
    {

        public  void OnControllerStartGrabInteractableObject(VRTK_InteractGrab grabbingObject)
        {
           // base.ControllerStartGrabInteractableObject(grabbingObject);
            Debug.Log("Grabbing IV Site");
        }

        public  void OnControllerStartUngrabInteractableObject(VRTK_InteractGrab grabbingObject)
        {
          //  base.ControllerStopGrabInteractableObject(grabbingObject);
            Debug.Log("UnGrabbing IV Site");
        }


        protected override void Update()
        {
            base.Update();

        }



    }
}