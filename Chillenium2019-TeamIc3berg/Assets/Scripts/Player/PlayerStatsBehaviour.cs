using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsBehaviour : MonoBehaviour
{
    public int hp;
    public float deathTimer;
    public bool isAlive;

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
        gm.SendMessage("PlayerDead");
        isAlive = false;
        this.gameObject.SetActive(false);
    }

    private void TakeDamage(int incomingDamage)
    {
        hp -= incomingDamage;
        
        if (hp <= 0)
            Die();
    }
}
