using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    void Awake()
    {
        
        
        //Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        //rb.bodyType = RigidbodyType2D.Dynamic;
        //rb.gravityScale = 0f;
        //var constraints = RigidbodyConstraints2D.FreezeAll;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Switch.PlatePress();
        Debug.Log("Plate pressed");
        // Send revocation method to blocker script
        
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        Switch.PlateReset();
        Debug.Log("Plate release");
        // Send revocation method to blocker script
    }
    
    

    private struct Switch
    {
        public static bool plateIsPressed;
        public static bool leverIsThrown;
        
        public static void PlatePress()
        {
            plateIsPressed = true;
        }

        public static void PlateReset()
        {
            plateIsPressed = false;
        }

        public static void Lever()
        {
            leverIsThrown = true;
        }

        public static void LeverReset()
        {
            leverIsThrown = false;
        }
    }
}
