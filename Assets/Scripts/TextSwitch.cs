using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSwitch : Interactable
{
    public override string GetDescription(){
        return "Hold [E] to read the passage.";
    }

    public override void Interact(){
        Debug.Log("Reading!");
    }
}
