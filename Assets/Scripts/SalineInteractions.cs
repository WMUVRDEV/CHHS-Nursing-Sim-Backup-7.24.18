using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalineInteractions : ItemInteraction {
	

	public bool SalineBagHanging;
	public bool SalineBagSpiked;


	public void SalineBagHung(){
		
		SalineBagHanging = true;
		
		if (SalineBagSpiked){
			Task.CheckTasks(true);
		}
	}
	
	public void SalineBagConnected(){
		SalineBagSpiked = true;
		if(SalineBagHanging){
			Task.CheckTasks(true);
		}
		
	}
	
	
	public void SalineBagRemoved(){
		Task.isComplete = false;
	}
	
}
