using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AttackBehaviour : MonoBehaviour
{
    
    public PlayerMovement owningPlayer;
    public float attackOffset;
    public Vector2 movementVector;
    public float attackRadius;
    private float horizontal;
    private float vertical;
    
    
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
        if (Input.GetButtonDown("Fire1"))
        {
            //Get all targets in range
            Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            //attack second closest target (so as to not hit self)
            if (targetsInRange.Length >= 1)
            {
                targetsInRange[0].SendMessage("TakeDamage");
                Debug.Log("Hit" + targetsInRange[1].name);
            }
        }
    }
}
