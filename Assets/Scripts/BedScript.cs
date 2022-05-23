using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedScript : Interactable
{
    private TimerScript timer;

    public void Awake()
    {
        // neat lil' method that lets me delay the awake function until TimerObj is in the picture.
        Invoke("Setup", 5.5f);
        
    }

    void Setup()
    {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
    }

    public override string GetDescription()
    {
        return "Press [E] to wait until Dawn.";
    }

    public override void Interact(bool alt = false)
    {
        timer.dayOver = true;
    }

}
