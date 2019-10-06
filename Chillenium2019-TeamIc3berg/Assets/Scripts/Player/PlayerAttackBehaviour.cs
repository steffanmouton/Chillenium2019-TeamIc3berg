
using UnityEngine;

public enum AttackState
{
    Ready,
    Reloading
}
public class PlayerAttackBehaviour : MonoBehaviour
{
    public PlayerMovement owningPlayer;
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
        if (Input.GetAxisRaw("Fire1") < -.01f && reloadingTimer > reloadTime)
        {
            SoundManagerScript.PlaySound("attackSound");
            reloadingTimer = 0;
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
        }
        else
        {
            action = false;
        }
    }
}
