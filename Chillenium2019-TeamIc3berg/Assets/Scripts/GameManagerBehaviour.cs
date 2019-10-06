using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    private int currentLevel = 0;
    public bool finalLevel = false;
    
   // private UnityAction nextLevelListener;
    
    void Awake ()
    {
        //nextLevelListener = new UnityAction (LoadNextLevel);
    }

    private void OnEnable()
    {
       // EventManager.StartListening("LevelComplete", nextLevelListener);
    }

    private void OnDisable()
    {
      //  EventManager.StartListening("LevelComplete", nextLevelListener);
    }

    private void LoadNextLevel()
    {
        currentLevel += 1;
        SceneManager.LoadScene(currentLevel);
    }
}
