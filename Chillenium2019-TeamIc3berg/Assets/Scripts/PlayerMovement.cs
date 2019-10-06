using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DashState 
{
    Ready,
    Dashing,
    Cooldown
}

public class PlayerMovement : MonoBehaviour
{



    public float moveSpeed = 5f;
    public float dashMultiplier;
    public float dashCooldown;
    public float maxDash;
    public Rigidbody2D rb;
    bool faceRight = true;
    public Vector2 movement;
    private SpriteRenderer sr;


    public DashState dashState = DashState.Ready;
    private float dashTimer = 0;

    public Vector2 savedVelocity;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player Colliding with: " + other.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("HorizontalPlayerOne");
        movement.y = Input.GetAxisRaw("VerticalPlayerOne");

        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
                if (isDashKeyDown)
                {
                    dashState = DashState.Dashing;
                }

                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime;
                if (dashTimer >= maxDash)
                {
                    dashTimer = dashCooldown;
                    dashState = DashState.Cooldown;
                }

                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }

                break;

        }
        
    }
    void FixedUpdate()
    {
        //movement
        //if moving

        if (Input.GetAxisRaw("HorizontalPlayerOne") > 0.5f || Input.GetAxisRaw("HorizontalPlayerOne") < -0.5f)
        {

            if (Input.GetAxisRaw("HorizontalPlayerOne") > 0.5f & !faceRight)
            {
                faceRight = true;
                Vector3 scale = transform.localScale;
                sr.flipX = false;
                transform.localScale = scale;

            }
            else if (Input.GetAxisRaw("HorizontalPlayerOne") < -0.5f & faceRight)
            {

                faceRight = false;
                Vector3 scale = transform.localScale;
                sr.flipX = true;
                transform.localScale = scale;
            }

        }
            
        //Check for dash and multiply if true
        if (dashState == DashState.Dashing)
          moveSpeed *= dashMultiplier;
            
        //Move the player
        rb.MovePosition(rb.position + Time.fixedDeltaTime * moveSpeed * movement);
    }
}
