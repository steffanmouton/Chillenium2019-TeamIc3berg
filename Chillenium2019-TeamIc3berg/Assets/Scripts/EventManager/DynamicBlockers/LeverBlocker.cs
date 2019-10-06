using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBlocker : MonoBehaviour
{

    private bool activate;
    private bool playerAction;
    private int counter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerAction && counter == 0)
        {
            activate = true;
            counter += 1;
        }

        if (playerAction && counter == 1)
        {
            activate = false;
            counter -= 1;
        }
        
    }

    private void Update()
    {
        playerAction = FindObjectOfType<PlayerAttackBehaviour>().action;
        if (playerAction)
        {
            Debug.Log("LeverAction");
        }
    }
}
