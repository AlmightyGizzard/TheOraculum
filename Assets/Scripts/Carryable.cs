using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : Interactable
{
    private TopDownController player;
    public float itemWeight;
    public bool carrying = false;

    public override string GetDescription()
    {
        return "Hold [F] to pick up.";
    }

    public override void Interact(bool alt = false)
    {
        Debug.Log("Carrying!");
        carrying = true;
        player.moveSpeed = player.baseMove - itemWeight;
        // if item is particularly heavy, restrict rotation - reducing the player to dragging/pushing
        if(itemWeight > 2)
        {
            //player.carrying = true;
        }
        
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<TopDownController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (carrying)
        {
            transform.position = player.anchor.transform.position;
        }
        carrying = false;
    }
}
