﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventResponderExample : MonoBehaviour
{
    private UnityAction someListener;
    
    void Awake ()
    {
        someListener = new UnityAction (SomeFunction);
    }

    void OnEnable ()
    {
        EventManager.StartListening("test", someListener);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("test", someListener);
    }

    void SomeFunction ()
    {
        Debug.Log ("Some Function was called!");
    }

    void SomeOtherFunction ()
    {
        Debug.Log ("Some Other Function was called!");
    }

    void SomeThirdFunction ()
    {
        Debug.Log ("Some Third Function was called!");
    }
}
