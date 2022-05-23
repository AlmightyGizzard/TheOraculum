using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float dayLength; 
    public TextMeshProUGUI text;
    [SerializeField]
    float countdown;
    float nightLength;
    public bool dayOver;

    public List<GameObject> lightsDorms;
    public List<GameObject> lightsLibrary;

    public List<GameObject> corridorWest;
    public List<GameObject> corridorNorth;
    public List<GameObject> corridorEast;
    // TODO: we need a set for each of the other 3 sections of the map - plus the corridors leading to the Hub. 
    // We will also need to sort the code so that all 4 of these sections start losing light in sync with each other - 
    // we don't want to lose light in section A, then B, then C etc. 

    // Past Dom suggests that if a clever solution cannot be found, simply ensure that all light sets contain the same number of lights - that way
    // the for loop can use 1 set for the loop without throwing errors on the others.  

    private void Awake()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        dayOver = false;
        countdown = dayLength;
        float halfday = dayLength / 2;
        nightLength = dayLength / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
            double b = System.Math.Round(countdown-nightLength, 0);
            if(b > -1)
            {
                text.text = "Daytime left: " +b.ToString();
            }
            

            // We want an each light going out in sequence at a regular pace
            float timePerLight = (nightLength/2) / lightsDorms.Count;

            // Check if each light should be off. 
            for(int i = lightsDorms.Count; i > 0; i--)
            {
                // If the timer is less than the amount of time per light multiplied by its position in the list, 
                // turn it off. Half of the nightLength is added here so that it all happens in the 3rd quarter of the day,
                // leaving a period of time where all lights are off. 
                if(countdown < (i * timePerLight)+(nightLength/2))
                {
                    lightsDorms[i - 1].SetActive(false);
                    // As you cas see, I've employed the lazy method - I don't have the time otherwise.
                    lightsLibrary[i - 1].SetActive(false);
                }
            }

            timePerLight = (nightLength / 4) / corridorWest.Count;

            // Check if each light should be off. 
            for (int i = corridorWest.Count; i > 0; i--)
            {
                // If the timer is less than the amount of time per light multiplied by its position in the list, 
                // turn it off. a quarter of the nightLength is added here so that it all happens in the 6th eighth of the day,
                // leaving a period of time where all lights are off. 
                if (countdown < (i * timePerLight) + (nightLength / 4))
                {
                    corridorEast[i - 1].SetActive(false);
                    // As you cas see, I've employed the lazy method - I don't have the time otherwise.
                    corridorNorth[i - 1].SetActive(false);
                    corridorWest[i - 1].SetActive(false);
                }
            }


        }
        else
        {
            dayOver = true;
            text.text = "Expired!";
        }
    
    }
}
