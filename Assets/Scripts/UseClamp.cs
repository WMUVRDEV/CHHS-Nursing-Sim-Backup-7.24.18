namespace VRTK.Examples
{
    using UnityEngine;

    public class UseClamp : VRTK_InteractableObject
    {
      
        public Scenario_Transfusion scenarioManager;
        public ivInteractions ivSystem;
        public int clampID;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);

	        //  ivSystem.ClampOpen(clampID);
            
            Debug.Log("using clamp " + clampID);
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
	        //ivSystem.ClampClosed(clampID);
        }

        protected void Start()
        {
            //rotator = transform.Find("Glove");
        }

        protected override void Update()
        {
            base.Update();
          
        }
    }
}