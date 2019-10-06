using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicBlocker : MonoBehaviour
{

    private bool isClosed;
    public Transform trans;

    void Awake()
    {
        isClosed = true;
        Debug.Log("this is awake");
    }

    void Update()
    {
        //Vector3 vec = transform.position;

        isClosed = FindObjectOfType<Switches>().activateBlock;
        if (isClosed)
        {
            //vec.z = 1;
            trans.position = new Vector3(3.25f, -8.4f, -1.0f);
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if(!isClosed)
        {
            //vec.z = -1;
            trans.position= new Vector3(3.25f, -8.4f, 1.0f);
            GetComponent<BoxCollider2D>().enabled = false;
        }
        
        Debug.Log(isClosed);
    }
    
}
