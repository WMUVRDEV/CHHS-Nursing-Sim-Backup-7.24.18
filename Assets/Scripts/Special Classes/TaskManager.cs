using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.WSA.WebCam;

public class TaskManager : MonoBehaviour {
	
	public static TaskManager instance;
	
	void Awake()
	{
		instance = this;
//	    Debug.Log(xTasks.Count());
	   // GameObject	newPipe = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
	}
	

    public string taskGroupName;
    public int taskGroupNumber;
    //public Task[] Tasks;
    //public xTask[] xTasks;
    public List<ItemInteraction> Tasks = new List<ItemInteraction>();
    public bool isComplete;
    public int trueCount;
    private string myString;

    void Start()
    {
       // xTasks = FindObjectOfType<ItemInteraction>();
       
    }
    
    public void CheckTasks(Task currentTask)
    
    {
        
      //  Debug.Log("currentTask "+ currentTask.taskName);
      //  Debug.Log(xTasks.Count());
        
        
        foreach (ItemInteraction task in Tasks)
        {


            if (!task.Task.isComplete)
            {
                if (currentTask.taskNumber > task.Task.taskNumber)
                {
                    Debug.Log("Task# " + task.Task.taskNumber + " : " + task.Task.taskName +
                              " should have been completed before " + currentTask.taskName);
                }
                else
                {
                    Debug.Log("Task " + currentTask.taskName + " was completed correctly");
                }
            }
        }

    }
}
