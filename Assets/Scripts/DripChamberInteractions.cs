using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripChamberInteractions : ItemInteraction {
	

	public bool dripChamberPrimed;
	public bool ivSnapped;
	
	
	public void IVInSnapZone(){
		ivSnapped = true;
	}
	
	public void DripPrimed(){
		if(ivSnapped){
			Task.CheckTasks(true);
		}
	}

}
