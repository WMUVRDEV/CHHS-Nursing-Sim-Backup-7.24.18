using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaniCollideScript : MonoBehaviour {

    public HandSanitizer sanitizer;


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
    }



    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "dollop")
        {
            Destroy(collider.gameObject);
            Debug.Log("Sani Hits the Hand " + gameObject.name);
            sanitizer = GameObject.Find("HandSanitizerDispenser").GetComponent<HandSanitizer>();
            Debug.Log(transform.parent.transform.parent.name);
            //sanitizer.leftSanitized
            sanitizer.Sanitized();
        }
    }
}
