﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool faceRight = true;
    public Vector2 movement;
    private SpriteRenderer sr;
    public Animator anim;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("HorizontalPlayerOne");
        movement.y = Input.GetAxisRaw("VerticalPlayerOne");

        anim.SetFloat("vertical",movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }
    void FixedUpdate(){
        //movement
        //if moving
        
        if(Input.GetAxisRaw("HorizontalPlayerOne")> 0.5f || Input.GetAxisRaw("HorizontalPlayerOne") < -0.5f){
            
            if(Input.GetAxisRaw("HorizontalPlayerOne") >0.5f & !faceRight){
                faceRight = true;
                Vector3 scale = transform.localScale;
                sr.flipX = false;
                transform.localScale = scale;
                
            }else if(Input.GetAxisRaw("HorizontalPlayerOne") <-0.5f & faceRight){
                
                faceRight = false;
                Vector3 scale = transform.localScale;
                sr.flipX = true;
                transform.localScale = scale;
            }
            
        }
       
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
