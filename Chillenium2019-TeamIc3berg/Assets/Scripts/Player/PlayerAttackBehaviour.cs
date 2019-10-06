using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    public PlayerMovement owningPlayer;
    public float attackOffset;
    public Vector2 movementVector;
    public float attackRadius;
    private float horizontal;
    private float vertical;

    public bool action = false;
    
    // Update is called once per frame

    private void Start()
    {
       
    }
    
    void FixedUpdate()
    {
        movementVector.x = owningPlayer.movement.x;
        movementVector.y = owningPlayer.movement.y;
        
        if (movementVector.magnitude > .5f)
            transform.localPosition = new Vector3(movementVector.normalized.x * attackOffset, movementVector.normalized.y * attackOffset, 0);
        
        // Melee Attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            action = true;
            //Get all targets in range. (layerMask 9 = Players)
            Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            Debug.Log("Attack Registered");
            
            // Debug line from attack to player
            //Debug.DrawLine(transform.position, owningPlayer.transform.position);
            
            foreach (var t in targetsInRange)
            {
                t.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Hit: " + t.name);
            }
            //attack second closest target (so as to not hit self)
            /*if (targetsInRange.Length >= 1)
            {
                targetsInRange[0].SendMessage("TakeDamage");
                Debug.Log("Hit" + targetsInRange[0].name);
            }*/
            
            
        }
        else
        {
            action = false;
        }
    }
}
