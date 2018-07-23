using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ConsentForm : ItemInteraction {

    
    public AudioClip writingSound;
    
    public bool isSigning = false;
    public bool signingComplete = false;
    
    public Material formMat;
    public Material signedFormMat;
    public GameObject clipboardForm;
    public Texture2D formBlank;
    public Texture2D formSigned;
    public Material[] CurMaterial;
    
    public PlayableDirector playable;
    
    void Start()
    {
        formMat.mainTexture = formBlank;  
    }
    
    public override void Grabbed()
    {
        base.Grabbed();
    }
    
    public override void Unsnapped()
    {
        thisAudio.Stop();
        isSigning = false;
    }

    public override void Snapped (){
       // Debug.Log("Snapped was called");
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
    
   
    
    IEnumerator Signing()
    {
        Debug.Log("Signing");
        playable.Play();
        yield return new WaitForSeconds(5);
        if (isSigning){
            isSigning=false;
            signingComplete = true;
            Task.CheckTasks(true);
//            Debug.Log("Signing Complete");
            thisAudio.Stop();
            formMat.mainTexture = formSigned;
        }
        thisAudio.Stop();
       
    }
    
}
