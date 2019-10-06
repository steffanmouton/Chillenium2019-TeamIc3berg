using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlateBehaviour : MonoBehaviour
{
    public GameManagerBehaviour gm;

    public SpriteRenderer sr;
    
    public Sprite offSprite;
    public Sprite onSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = offSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        sr.sprite = onSprite;
        gm.SendMessage("AddObjectivePoint");
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        sr.sprite = offSprite;
        gm.SendMessage("MinusObjectivePoint");
    }
}
