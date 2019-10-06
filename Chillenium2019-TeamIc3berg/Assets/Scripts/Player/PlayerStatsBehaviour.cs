using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wilberforce.FinalVignette;

public class PlayerStatsBehaviour : MonoBehaviour
{
    public int hp;
    public float deathTimer;
    public bool isAlive;
    public Vector3 hitColor;
    public Camera mc;
    public Rigidbody2D rb;
    public DistanceJoint2D anchor;
    
    public GameManagerBehaviour gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Die()
    {
        anchor.enabled = false;
        rb.MovePosition(new Vector2(1000000,100000));
        gm.SendMessage("PlayerDead");
        isAlive = false;
        Destroy(this.gameObject,  .5f);
    }

    private void TakeDamage(int incomingDamage)
    {
        hp -= incomingDamage;
        
        if (hp <= 0)
            Die();
    }
    
}
