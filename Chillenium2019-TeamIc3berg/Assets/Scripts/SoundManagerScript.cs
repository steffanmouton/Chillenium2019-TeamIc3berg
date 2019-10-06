using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip panelSound, attackSound;

    private static AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        attackSound = Resources.Load<AudioClip>("AttackSound");
        aSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "panelSound":
                aSource.PlayOneShot(panelSound);
                break;
            case "attackSound":
                aSource.PlayOneShot(attackSound);
                break;
        }
    }
}
