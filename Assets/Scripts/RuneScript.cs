using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RuneScript : Interactable
{
    public TextMeshPro text;
    public float glow = 0f;
    public float glowDecay = 0.05f;
    public RuneSystem system;
    string st = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public int currentLetter; 

    public override string GetDescription()
    {
        if(glow <= 0.1f)
        {
            glow += glowDecay;
        }
        return "Press [E] to scrawl.";
    }

    public override void Interact(bool alt = false)
    {
        if (alt)
        {
            system.Guess();
        }
        else
        {
            Debug.Log("Reading!");
            if (currentLetter >= st.Length - 1)
            {
                currentLetter = 0;
            }
            else
            {
                currentLetter++;
            }
            text.color = Color.black;
            text.text = st[currentLetter].ToString();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        system = GetComponentInParent<RuneSystem>();
        st = system.st;
        char value = char.Parse(text.text);
        currentLetter = st.IndexOf(value);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        text.outlineWidth = glow;
        if(glow >= 0)
        {
            glow -= glowDecay;
        }
    }
}
