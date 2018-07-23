using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBagHangSpike : ItemInteraction {
	
	public bool BloodBagHanging;
	public bool BloodBagSpiked;


	public void BloodBagHung(){
		
		BloodBagHanging = true;
		
		if (BloodBagSpiked){
			Task.CheckTasks(true);
		}
	}
	
	public void BloodBagConnected(){
		BloodBagSpiked = true;
		if(BloodBagHanging){
			Task.CheckTasks(true);
		}
		
	}
	
	
	
	public void BloodBagRemoved(){
		Task.isComplete = false;
	}
	
}
