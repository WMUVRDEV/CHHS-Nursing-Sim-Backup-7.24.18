using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodAdminChecklist : MonoBehaviour {

    public Text bloodAdminTitle;

    public List<Button> bloodAdminButtons;

    public List<Text> bloodAdminButtonText;

    public int pageNumber = 7;

    public List<string> questions;

    public bool medicalOrder;

    public bool informedConsent;

    public List<int> patientID;

    public List<string> patientName;

    public List<string> bloodgroupandtyp;

    public List<string> expiration;

    public bool inspectBlood;



    //public 
        
        void Start () {
        //  pageNumber++;

        switch (pageNumber)
        {
            case 0:
                // Does the patient have a medical order for a blood transfusion?

                break;
            case 1:
                //Has the patient given consent?
                break;
            case 2:
                //What is the patient identification number?

                for (int i = 0; i < bloodAdminButtonText.Count; i++)
                {
                    Debug.Log(i);
                    bloodAdminButtonText[i].text = patientID[i].ToString();
                }
                break;
            case 3:
                //What is the patients name?

                bloodAdminTitle.text = questions[3];


                for (int i = 0; i < bloodAdminButtonText.Count; i++)
                {
                    Debug.Log(i);
                    bloodAdminButtonText[i].text = patientName[i];
                }
                //bloodAdminButtonText[0].text = patientName[0];
                break;

            case 4:
                //What is the labeled blood group and blood type?

                for (int i = 0; i < bloodAdminButtonText.Count; i++)
                {
                    Debug.Log(i);
                    bloodAdminButtonText[i].text = bloodgroupandtyp[i];
                }
                break;
            case 5:
                //What is the labeled expiration date?

                for (int i = 0; i < bloodAdminButtonText.Count; i++)
                {
                    Debug.Log(i);
                    bloodAdminButtonText[i].text = expiration[i];
                }
                break;
            case 6:
                //Were blood clots, clumping, or gas bubbles found when inspecting?
                break;
            default:
                break;




        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
