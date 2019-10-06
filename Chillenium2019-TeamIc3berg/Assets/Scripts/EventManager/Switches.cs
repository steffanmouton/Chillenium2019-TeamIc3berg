using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    public bool activateBlock;
    // starts false for some reason, until player interacts with plate
    private void Start()
    {
        activateBlock = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        activateBlock = false;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        activateBlock = true;
    }
}