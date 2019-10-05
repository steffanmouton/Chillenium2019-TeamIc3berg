using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player4Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool faceRight = true;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("HorizontalPlayerFour");
        movement.y = Input.GetAxisRaw("VerticalPlayerFour");
    }
    void FixedUpdate(){
        //movement
        //if moving
        
        if(Input.GetAxisRaw("HorizontalPlayerFour")> 0.5f || Input.GetAxisRaw("HorizontalPlayerFour") < -0.5f){
            
            if(Input.GetAxisRaw("HorizontalPlayerFour") >0.5f & !faceRight){
                faceRight = true;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;    
                
            }else if(Input.GetAxisRaw("HorizontalPlayerFour") <-0.5f & faceRight){
                
                faceRight = false;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            
        }
       
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
