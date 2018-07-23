namespace VRTK.Examples
{
    using UnityEngine;

    public class UseSigmaDoor : VRTK_InteractableObject
    {
 
        public ivInteractions ivSystem;
        public bool doorOpen;


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
           
            if (!doorOpen)
            {
                ivSystem.OpenSigmaDoor();
                doorOpen = true;
                Debug.Log("Door True");
            }
            else
            {
                ivSystem.CloseSigmaDoor();
                doorOpen = false;
                Debug.Log("Door False");
            }


            
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
         
        }

        protected void Start()
        {
            ivSystem = GameObject.Find("IV_Interactions").GetComponent<ivInteractions>();
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}