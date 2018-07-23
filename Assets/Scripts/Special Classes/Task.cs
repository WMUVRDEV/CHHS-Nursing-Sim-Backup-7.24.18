using UnityEngine;

[System.Serializable]
public class Task : System.Object
{
	public int taskNumber;
	public bool isComplete;
	public string taskName;
	//public xTask thisTask;
	


	public void CheckTasks(bool completed)
	{
 	//	Debug.Log("Checking xTask " + taskName + " # " + taskNumber);
		
		Task thisTask = this;
		isComplete = completed;
		
		if (thisTask != null)
		{
			TaskManager.instance.CheckTasks(thisTask);
		}
	}
}