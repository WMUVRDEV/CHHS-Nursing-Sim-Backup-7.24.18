using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftObjectHit : MonoBehaviour {

    // Use this for initialization
    private GameObject hitObject;
    public GameObject hardObject;

    public AudioSource softCollisionSound;

    public AudioClip[] clipSource;

    private int arraySize;
    private int ranNumber;

    public void Start()
    {
        arraySize = clipSource.Length;
        ranNumber = Random.Range(0, arraySize);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "SoftObject")
        {
            softCollisionSound.clip = clipSource[ranNumber];
            softCollisionSound.Play();

        }
    }
}
