using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;



public class ShadowLoader : MonoBehaviour
{
    private TopDownController player;
    private Light2D visionCone;

    private CompositeShadowCaster2D shadowGroup;
    private float cutOff = 12;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownController>();
        shadowGroup = GetComponent<CompositeShadowCaster2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shadowGroup.enabled = true;
        if(Vector3.Distance(player.transform.position, transform.position) > cutOff)
        {
            shadowGroup.enabled = false;
        }
    }
}
