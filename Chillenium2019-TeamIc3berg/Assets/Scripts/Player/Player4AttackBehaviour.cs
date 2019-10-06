using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4AttackBehaviour : MonoBehaviour
{
    public player4Move owningPlayer;
    public float attackOffset;
    public Vector2 movementVector;
    public float attackRadius;
    private float horizontal;
    private float vertical;
    
    public float reloadTime = 1;
    public float reloadingTimer = 0;

    public bool action = false;
    
    // Update is called once per frame

    private void Start()
    {
       
    }
    
    private void Update()
    {
        reloadingTimer += Time.deltaTime;
    }
    
    void FixedUpdate()
    {
        movementVector.x = owningPlayer.movement.x;
        movementVector.y = owningPlayer.movement.y;
        
        if (movementVector.magnitude > .5f)
            transform.localPosition = new Vector3(movementVector.normalized.x * attackOffset, movementVector.normalized.y * attackOffset, 0);
        
        // Melee Attack
        if (Input.GetButtonDown("Fire4") && reloadingTimer > reloadTime)
        {
            SoundManagerScript.PlaySound("attackSound");
            reloadingTimer = 0;
            action = true;
            //Get all targets in range. (layerMask 9 = Players)
            Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            Debug.Log(this.name + ": Attack Registered");
            
            // Debug line from attack to player
            //Debug.DrawLine(transform.position, owningPlayer.transform.position);
            
            foreach (var t in targetsInRange)
            {
                t.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
                Debug.Log(this.name + " Hit: " + t.name);
            }
        }
        else
        {
            action = false;
        }
    }
}
