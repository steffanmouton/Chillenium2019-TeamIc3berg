using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsBehaviour : MonoBehaviour
{
    public int hp = 1;

    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 1)
        {
            
        }
    }

    private void Die()
    {
        
    }

    private void TakeDamage(int incomingDamage)
    {
        hp -= incomingDamage;
    }
}
