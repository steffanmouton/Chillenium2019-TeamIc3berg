using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    bool faceRight = true;
    Vector2 movement;

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("HorizontalPlayerThree");
        movement.y = Input.GetAxisRaw("VerticalPlayerThree");

        anim.SetFloat("vertical",movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }
    void FixedUpdate(){
        //movement
        //if moving
        
        if(Input.GetAxisRaw("HorizontalPlayerThree")> 0.5f || Input.GetAxisRaw("HorizontalPlayerThree") < -0.5f){
            
            if(Input.GetAxisRaw("HorizontalPlayerThree") >0.5f & !faceRight){
                faceRight = true;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;    
                
            }else if(Input.GetAxisRaw("HorizontalPlayerThree") <-0.5f & faceRight){
                
                faceRight = false;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            
        }
       
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
