using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeZone : MonoBehaviour {

    public OvrAvatar avatar;
    public GameObject rightHandPointerPose;
    private GameObject tipOfPointerFinger;

    public void OnTriggerEnter()
    {
        avatar.RightHandCustomPose = rightHandPointerPose.transform;

        if (rightHandPointerPose == null) { Debug.Log("Custom Hand Is Null"); }

        if (avatar.RightHandCustomPose != null) { Debug.Log("Right Hand Present"); }

        if (GameObject.Find("hands:b_r_index_ignore") != null)
        {
            tipOfPointerFinger = GameObject.Find("hands:b_r_index_ignore");
            tipOfPointerFinger.tag = "poke";
            Collider tipCollider = tipOfPointerFinger.GetComponent<SphereCollider>();

            if (tipCollider == null)
            {
                tipOfPointerFinger.AddComponent<SphereCollider>().radius = 0.01f;

            }

            else
            {
                Rigidbody fingerRB = tipOfPointerFinger.AddComponent<Rigidbody>();
                if (fingerRB != null)
                {
                    fingerRB.isKinematic = true;
                    fingerRB.useGravity = false;
                    tipOfPointerFinger.AddComponent<DetectCollision>();
                }
            }
        }

        else if (GameObject.Find("hands:b_r_index_ignore") == null)
        {
            Debug.Log("Index Finger Not Found");

        }

        // StartCoroutine(WaitTime());
    }

    public void OnTriggerExit()
    {
        avatar.RightHandCustomPose = null;
        tipOfPointerFinger.tag = "Untagged";
        Destroy(tipOfPointerFinger.GetComponent<BoxCollider>());
        Destroy(tipOfPointerFinger.GetComponent<Rigidbody>());
    }


}
