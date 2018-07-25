using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokedButton : MonoBehaviour {

    public Button thisButton;
    public Color pressedColor;
    public Color baseColor;
    private ColorBlock cb;
    
    void Start()
    {
        thisButton = GetComponent<Button>();
        
        cb = thisButton.colors;
        cb.normalColor = baseColor;
        thisButton.colors = cb;
    }


    public void pokedButton()
    {

        Debug.Log("Poke");
        cb.normalColor = pressedColor;
        thisButton.colors = cb;
        thisButton.onClick.Invoke();
    }

    public void unPokedButton()
    {
        Debug.Log("unPoke");
        cb.normalColor = baseColor;
        thisButton.colors = cb;
    }
    
}
