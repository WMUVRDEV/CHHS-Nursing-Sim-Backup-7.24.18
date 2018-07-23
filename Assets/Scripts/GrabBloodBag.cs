namespace VRTK.Examples
{
    using UnityEngine;

    public class GrabBloodBag : VRTK_InteractableObject
    {
        //public Text consoleOutput;

        public BloodBagInteractions BloodBagSystem;

        public override void Grabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Grabbed(grabbingObject);
            //Debug.Log("Grabbing Blood Bag");
            BloodBagSystem.IsGrabbed();
        }

        public override void Ungrabbed(VRTK_InteractGrab grabbingObject)
        {
            base.Ungrabbed(grabbingObject);
            //Debug.Log("UnGrabbing Blood Bag");
        }


        protected override void Update()
        {
            base.Update();
        }



    }
}