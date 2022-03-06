using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSwitch : Interactable
{
    public GameObject UI_Panel;
    private string text;
    public bool reading = false;
    public override string GetDescription(){
        return "Hold [E] to read the passage.";
    }

    public override void Interact(bool alt = false){
        Debug.Log("Reading!");
        reading = true;
    }

    public void FixedUpdate()
    {
        UI_Panel.SetActive(reading);
        reading = false;
    }
}
