using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidTween : MonoBehaviour {
    //public Material Saline;
    public Renderer rend;
    public float fillSpeed;
    public bool toggle = true;
    float offset;
    int count = 0;

    public bool on = false;


    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        //InvokeRepeating("SalineAnimation", time: 1, repeatRate: .001f);
        //if(offset < -.5f)
        //{
        //    CancelInvoke("SalineAnimation");
        //}
    }

    // Update is called once per frame
    void Update () {

        if (offset < -.5f)
        {
            CancelInvoke("SalineAnimation");
        }
    }

    public void SalineAnimation()
    {
        offset = Time.time * (-fillSpeed);
        rend.material.mainTextureOffset = new Vector2(0, offset);
    }

    public void StartRepeating()
    {
        InvokeRepeating("SalineAnimation", time: 1, repeatRate: .001f);
    }
}
