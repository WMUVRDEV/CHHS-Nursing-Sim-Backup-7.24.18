namespace VRTK.Examples
{
    using UnityEngine;

    public class UseSanitizer : VRTK_InteractableObject
    {
       
        public Scenario_Transfusion ScenarioManager;
        public SanitizerInteractions saniManager;

        public GameObject rightHand, leftHand;

        public Collider saniCollider;


        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);

            rightHand = GameObject.Find("hand_right_renderPart_0");
            leftHand = GameObject.Find("hand_left_renderPart_0");

            if (usingObject.name == "RightController")
            {
                if (saniCollider == null)
                {
                    saniCollider = leftHand.AddComponent<SphereCollider>();
                    saniCollider.isTrigger = true;
                    leftHand.AddComponent<SaniCollideScript>();
                }

            }
            
            else
            {
                if (saniCollider == null)
                {
                    saniCollider = rightHand.AddComponent<SphereCollider>();
                    saniCollider.isTrigger = true;
                    rightHand.AddComponent<SaniCollideScript>();
                }

            }
            saniManager.Dispense();
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}