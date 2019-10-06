using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsBehaviour : MonoBehaviour
{
    public int hp;
    public float deathTimer;
    public bool isAlive;
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
        isAlive = false;
        Destroy(this.gameObject, deathTimer);
    }

    private void TakeDamage(int incomingDamage)
    {
        hp -= incomingDamage;
        
        if (hp <= 0)
            Die();
    }
}
