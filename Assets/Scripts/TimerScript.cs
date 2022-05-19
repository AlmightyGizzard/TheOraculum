using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    float countdown = 30.0f;
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
            double b = System.Math.Round(countdown, 2);
            text.text = b.ToString();
        }
        
        if(countdown < 0)
        {
            Debug.Log("Timer Expired!");
            text.text = "Expired!";
        }
    }
}
