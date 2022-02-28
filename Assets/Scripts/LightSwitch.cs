using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightSwitch : Interactable
{
    public List<Light2D> m_lights;
    public bool isOn;

    private void Start()
    {
        UpdateLights();
    }

    void UpdateLights()
    {
        foreach(Light2D light in m_lights){
            light.enabled = isOn;
        }
    }

    public override string GetDescription()
    {
        if (isOn) return "Press [E] to turn <color=red>off</color> the light.";
        return "Press [E] to turn <color=green>on</color> the light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateLights();
    }
}
