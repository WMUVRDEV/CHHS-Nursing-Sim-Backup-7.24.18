
    using UnityEngine;
    using UnityEngine.UI;

    public class Keypad : MonoBehaviour
    {
        public InputField input;
        public Text testText;
        public AudioSource thisAudio;
        public string correctCode;
        public ivInteractions ivSystem;

        public string line1;
        public string line2;
        public string line3;

        public int currentLine;

    public void ClickKey(string character)
        {
            thisAudio.Play();
            input.text += character;
            testText.text += character;
        }

        public void Backspace()
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
                testText.text = testText.text.Substring(0, testText.text.Length - 1);
            }
        }

        public void Enter()
        {
            if(input.text == correctCode){
                testText.text = "Flow Set to 30cc/min";
                ivSystem.operateIV();
            }
            else{
               testText.text = "You Killed Her! " + input.text;
        }
        }

    public void UpArrow()
    {
        if (currentLine == 1)
        {
            testText.text = (">" + line3);
            currentLine=3;
        }
        else if (currentLine == 2)
        {
            testText.text = (">" + line1);
            currentLine = 1;
        }
        else
        {
            testText.text = (">" + line2);
            currentLine = 2;
        }
    }

    public void DownArrow()
    {
        if (currentLine == 1)
        {
            testText.text = (">" + line2);
            currentLine = 2;
        }
        else if (currentLine == 2)
        {
            testText.text = (">" + line3);
            currentLine = 3;
        }
        else
        {
            testText.text = (">" + line1);
            currentLine = 1;
        }
    }

    }
