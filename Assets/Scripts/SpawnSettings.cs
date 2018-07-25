using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettings : MonoBehaviour {
	public GameObject leftBedDest;
	public GameObject rightBedDest;
    GameObject LocalAvatObj;
    GameObject VRTKObj;

    public bool leftBedSpawn = false;
    public bool rightBedSpawn = false;


	
	
	// Use this for initialization
	void Start () {
        LocalAvatObj = GameObject.Find("LocalAvatar");
        VRTKObj = GameObject.Find("VRTK");
        CheckNull(VRTKObj);
        CheckNull(LocalAvatObj);
		spawnPoint();
	}

    private void Update()
    {
        //Debug.Log(LocalAvatObj.transform.position);
        CheckAvatarTransform();
    }

    //Select Spawn Point
    public void spawnPoint(){
		if(leftBedSpawn == true)
        {
            rightBedSpawn = false;
            LocalAvatObj.transform.position = leftBedDest.transform.position;
            VRTKObj.transform.position = leftBedDest.transform.position;
            leftBedDest.SetActive(false);
            Debug.Log("Left spawn point selected");
        }

        else if(rightBedSpawn == true)
        {
            leftBedSpawn = false;
            rightBedDest.SetActive(false);
            LocalAvatObj.transform.position = rightBedDest.transform.position;
            VRTKObj.transform.position = rightBedDest.transform.position;
            Debug.Log("Right spawn point selected");
        }

        else
        {
            Debug.Log("No spawn point selected");
        }
	}

    void CheckAvatarTransform()
    {
        if (rightBedSpawn == true) {
            if (LocalAvatObj.transform.position.z > -.4f)
            {
                rightBedDest.SetActive(true);
                LocalAvatObj.GetComponent<SpawnSettings>().enabled = false;
            }
        }

        else if (leftBedSpawn == true)
        {
            if (LocalAvatObj.transform.position.z < .9f)
            {
                leftBedDest.SetActive(true);
                LocalAvatObj.GetComponent<SpawnSettings>().enabled = false;
            }
        }
    }


    void CheckNull(GameObject test)
    {
        if(test == null)
        {
            Debug.Log(test.name + " Is Null");
            test.SetActive(false);
        }
    }
	
	
}