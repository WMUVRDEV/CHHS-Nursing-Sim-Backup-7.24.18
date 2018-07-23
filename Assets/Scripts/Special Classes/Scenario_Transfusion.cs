using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scenario_Transfusion : MonoBehaviour {

	public static Scenario_Transfusion instance;


    public Task[] taskList;
	public TaskManager[] taskGroup;
    
	public AudioSource thisAudio;
	public AudioClip writingSound;
	

	public int systolic;
	public int diastolic;
	public bool bpCuffAttached;
	public bool bpReadingInProgress;
	public bool bpIsRead;
	public Text bpReadout;
	public AudioClip bpSound;

	public Material ovrHandsOriginal;
	public Material glovesMaterial;
    public GameObject ovrLeftHand, ovrRightHand;
    public Material handsMaterialLeft;
    public Material handsMaterialRight;

	public bool glovesOn;

	public Camera LeftEyeCam;
	public Camera RightEyeCam;

	public GameObject mainRoom;
	public GameObject Lab;

    public MaskInteractions maskSystem;

    public Canvas messageCanvas;
    public Text messageText;
    public Canvas DebugCanvas;
    public bool showingDebug;

	public bool inLab; 
	
	void Awake()
	{
		instance = this;
	}


	void Start(){

		//Lab.SetActive(false);
		mainRoom.SetActive(true);
        messageCanvas.enabled = true;
        messageText.text = "Welcome to the Intravenous Transfusion Simulation";
		// StartCoroutine(HideMessage());
    }

	public void SetMessage(string newText)
	{
		messageText.text = newText;
	}



    void Update()
    {
        if (Input.GetAxis("Fire1") >0.1){
           //DebugCanvas.enabled = true;

        }
        else
        {
            //DebugCanvas.enabled = false;
        }
    }

/*    public void PutOnGloves(){
    	glovesOn = true;
        ovrLeftHand = GameObject.Find("hand_left_renderPart_0");
        ovrRightHand = GameObject.Find("hand_right_renderPart_0");
        handsMaterialLeft = ovrLeftHand.GetComponent<Renderer>().material;
        handsMaterialRight = ovrRightHand.GetComponent<Renderer>().material;
        handsMaterialLeft.SetColor("_BaseColor", Color.yellow);
        handsMaterialRight.SetColor("_BaseColor", Color.yellow);
    }*/

/*    public void ShowLab(){
    	Debug.Log("showing Lab");
    	mainRoom.SetActive(false);
    	Lab.SetActive(true);
    }*/

/* public void ShowMainRoom(){
 		mainRoom.SetActive(true);
    	Lab.SetActive(false);
    }*/
/*


	public void TakingBloodPressure(){
		thisAudio.clip = bpSound;

		bpCuffAttached = true;

		if (!bpIsRead){
			bpReadingInProgress = true;
				if (thisAudio !=null){
					thisAudio.Play();
					StartCoroutine(BloodPressure());
				}
		}
		else {
			Debug.Log("Already Signed");
		}
	}
*/


/*	public void signingClipboard (){
		thisAudio.clip = writingSound;

		if (!signingComplete){
			/isSigning = true;
				if (thisAudio !=null){
					thisAudio.Play();
					StartCoroutine(Signing());
				}
		}
		else {
			Debug.Log("Already Signed");
		}

	}*/


// IEnumerator Signing()
//    {
//    	Debug.Log("Signing");
//        yield return new WaitForSeconds(5);
//        isSigning=false;
//		signingComplete = true;
//		thisAudio.Stop();
//    }
//
/*     IEnumerator BloodPressure()
    {
    	Debug.Log("Blood Pressuring");
        yield return new WaitForSeconds(5);
		thisAudio.Stop();
		systolic = (Random.Range(100, 200));
		diastolic = (Random.Range(50, 99));
    }*/

    public void TouchCheck(GameObject touchedTag)
    {
        if(touchedTag.layer == 10)
        {
            Debug.Log("Out of Zone Object Touched");
        }

        if (touchedTag.layer == 10 && glovesOn)
        {
            Debug.Log("Out of Zone Object Touched with Gloves On");
        }
    }

/*    public void CheckTasks(int taskItem, int taskGroup)
    {
        Debug.Log("Checking Tasks");
        for (int i =0; i<=taskItem; i++)
        {
            if (!taskList[i].isComplete)
            {
                Debug.Log(taskList[i].taskName + " Not Complete");
                messageCanvas.enabled = true;
                messageText.text = (taskList[i].taskName + " must be completed before " + taskList[taskItem].taskName);
                StartCoroutine(HideMessage());
                return;
            }
            else
            {
                Debug.Log(taskList[i].taskName + " Complete");
                messageCanvas.enabled = true;
                messageText.text = (taskList[i].taskName + " was completed in the correct order");
                StartCoroutine(HideMessage());
            }
        }
    }

    public void CheckTaskGroup(int taskGroupNumber)
    {
        for(int i=0; i<=taskGroupNumber; i++)
        {
            if (!taskGroup[i].isComplete)
            {
                Debug.Log(taskGroup[i].taskGroupName + " Not Complete");
                messageCanvas.enabled = true;
                messageText.text = (taskGroup[i].taskGroupName + " must be completed before " + taskGroup[taskGroupNumber].taskGroupName);
                return;
            }
            else
            {
                Debug.Log(taskGroup[i].taskGroupName + " Complete");
                messageCanvas.enabled = true;
                messageText.text = (taskGroup[i].taskGroupName + " was completed in the correct order");
            }
        }
    }*/

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(3);
        messageCanvas.enabled = false;
        messageText.text = ("Should be hidden now completed in order");
    }





}
