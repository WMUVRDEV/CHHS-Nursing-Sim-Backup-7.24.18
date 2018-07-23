using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettings : MonoBehaviour {
	public GameObject IVSpawn;
	public GameObject FootOfBed;
	public GameObject BPMachine;
	
	public GameObject CameraRig;
	
	public bool IVSpawnPoint = false;
	public bool FootOfBedSpawn = false;
	public bool BPMachineSpawn = false;

	/* public bool IVSpawnPointToggle = true;
	public bool FootOfBedSpawnToggle = true;
	public bool BPMachineSpawnToggle = true;*/
	
	
	// Use this for initialization
	void Start () {
		spawnPoint();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		HideDestinationPoint();
	}
	
	//Fucntions
	
	//Select Spawn Point
	public void spawnPoint(){
		if (IVSpawnPoint == true){
			FootOfBedSpawn = false;
			BPMachineSpawn = false;
			CameraRig.transform.position = new Vector3(IVSpawn.transform.position.x, 0, IVSpawn.transform.position.z);
		}
		if (FootOfBedSpawn == true){
			IVSpawnPoint = false;
			BPMachineSpawn = false;
			CameraRig.transform.position = new Vector3(FootOfBed.transform.position.x, 0, FootOfBed.transform.position.z);
		}
		if (BPMachineSpawn == true){
			IVSpawnPoint = false;
			FootOfBedSpawn = false;
			CameraRig.transform.position =new Vector3(BPMachine.transform.position.x, 0, BPMachine.transform.position.z);
		}
	}
	//When on teleport location, turn of relevant GameObject
	public void HideDestinationPoint(){
		if (CameraRig.transform.position == IVSpawn.transform.position){
			IVSpawn.SetActive(false);
		}
		else{
			IVSpawn.SetActive(true);
		}
		if(CameraRig.transform.position == FootOfBed.transform.position){
			FootOfBed.SetActive(false);
		}
		else{
			FootOfBed.SetActive(true);
		}
		if(CameraRig.transform.position == BPMachine.transform.position){
			BPMachine.SetActive(false);
		}
		else{
			BPMachine.SetActive(true);
		}
	}
	
	
}