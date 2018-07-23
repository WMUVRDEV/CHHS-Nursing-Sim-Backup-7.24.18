using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class ItemInteraction : MonoBehaviour {
	
	//public string InteractionName ;
	public AudioSource thisAudio;
	//public AudioClip grabSound, snapSound, UseSound, completeSound;
	
	public Task Task = new Task();
	private AudioSource grabbedObjectAudio;

	private bool grabAudioPlayed;
	
	public virtual void Start (){
		thisAudio = GetComponent<AudioSource>();
		grabbedObjectAudio = GameObject.Find("Grab Object Audio").GetComponent<AudioSource>();
	}

	public virtual void Grabbed()
	{	
/*		if (!grabAudioPlayed)
		{
			grabbedObjectAudio.Play();
			grabAudioPlayed = true;
		}*/
	}
	
	public virtual void Ungrabbed (){
		//grabAudioPlayed = false;
	}
	
	public virtual void Use(){
		
	}
	
	public virtual void UnUse(){
		
	}

	
	public virtual void Snapped(){
		
	}
	
	public virtual void Unsnapped(){
		
	}
	
	
}
