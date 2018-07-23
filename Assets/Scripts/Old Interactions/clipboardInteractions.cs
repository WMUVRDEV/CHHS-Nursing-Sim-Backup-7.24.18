
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.Playables;

    public class clipboardInteractions : MonoBehaviour
    {
    
    public Task thisTask;
    public TaskManager thisTaskGroup; 
    public int taskNumber;

    public AudioSource thisAudio;
    public AudioClip grabAudio;

    public bool isSigning = false;
    public bool signingComplete = false;
    public AudioClip writingSound;
    public Material formMat;
    public Material signedFormMat;
	public GameObject clipboardForm;
	public Texture2D formBlank;
	public Texture2D formSigned;
    public Material[] CurMaterial;
    public PlayableDirector playable;
            
	    public  Task yTask = new Task(); 
	    

    void Start()
    {
	    formMat.mainTexture = formBlank;  
    }


    public void signingClipboard (){
        thisAudio.clip = writingSound;

        if (!signingComplete){
            isSigning = true;
                if (thisAudio !=null){
                    thisAudio.Play();
                    StartCoroutine(Signing());
                }
        }
        else {
            Debug.Log("Already Signed");
        }
    }

    public void Unsnapped()
    {
        thisAudio.Stop();
        isSigning = false;
    }


 IEnumerator Signing()
    {
	    Debug.Log("Signing");
        playable.Play();
        yield return new WaitForSeconds(5);
        if (isSigning){
            isSigning=false;
            signingComplete = true;
	        thisTask.CheckTasks(true);
	        
	     //   yTask.isComplete = true;       
	       // yTask.CheckTasks(yTask.taskNumber);
        }
        
        thisAudio.Stop();
	    formMat.mainTexture = formSigned;
    }

    }
