using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchManager : MonoBehaviour {

    public Scenario_Transfusion scenarioManager;

		
        void OnCollisionEnter (Collision other){
         
            if (scenarioManager.glovesOn)
            {
                    Debug.Log("Touched out of Zone");
    
            }
        else
        {
            Debug.Log("No Gloves on and Touched out of Zone");
        }

        }



	
}
