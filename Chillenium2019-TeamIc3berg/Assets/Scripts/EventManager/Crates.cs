using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    //for magnetic effect
    //private float force = 1.5f;

    void Awake()
    {
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;

        gameObject.AddComponent<BoxCollider2D>();

        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        
        //stationary
        rb.gravityScale = 0f;
        //goes up
        //rb.gravityScale = -1.5f;
        //goes down
        //rb.gravityScale = 1.5f;
        
        //slows angular rotation of crate, can be locked
        rb.angularDrag = 250;
        rb.drag = rb.mass = 10;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Crate.touchCrate = true;
        //GetComponent<Animation>().Play("PushingCrate");
        
        //Debug.Log("Collision start");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Crate.ResetCrate();
        //GetComponent<Animation>().Stop("PushingCrate");
        
        //Debug.Log("Collision stopped");
    }

    private struct Crate
    {
        public static bool touchCrate;
        public static void ResetCrate()
        {
            touchCrate = false;
        }
    }
}
