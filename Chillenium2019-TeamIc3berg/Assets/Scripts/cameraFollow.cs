using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    Vector3 offset;
    void FixedUpdate(){
        Vector3 desirePos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desirePos, smoothSpeed);
        transform.position = target.position;

        transform.LookAt(target);
    }
}
