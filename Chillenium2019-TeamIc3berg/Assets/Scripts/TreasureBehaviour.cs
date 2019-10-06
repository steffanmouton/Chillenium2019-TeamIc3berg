using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBehaviour : MonoBehaviour
{
    public GameManagerBehaviour gm;

    public bool endGame;
    // Start is called before the first frame update
    void Start()
    {
        endGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
         {
             if (endGame)
             {
                 gm.SendMessage("EndGame");
             }
         }
}
