using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    private int currentLevel = 0;
    public bool finalLevel = false;
    public int objectivePoints = 0;
    public GameObject treasure;
    public TreasureBehaviour tb;
    public bool combatOn = false;
    public Text instructionText;
    public bool objectiveComplete;

    public int numPlayersAlive = 4;
    
   // private UnityAction nextLevelListener;
    
    void Awake ()
    {
        //nextLevelListener = new UnityAction (LoadNextLevel);
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        
        if (objectivePoints == 4)
        {
            treasure.SetActive(true);
            instructionText.color = Color.red;
            instructionText.text = "One, For All: There's only one Treasure... You know what to do.";
            objectiveComplete = true;
        }

        if (numPlayersAlive < 2 && objectiveComplete)
        {
            instructionText.color = Color.yellow;
            instructionText.text = "You're the One. Claim your treasure";
            tb.endGame = true;
        }

        if (numPlayersAlive < 2 && !objectiveComplete)
        {
            instructionText.color = Color.magenta;
            instructionText.text = "Not enough Mindpower... You must restart the trial.";
        }
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

    private void AddObjectivePoint()
    {
        objectivePoints += 1;
    }

    private void MinusObjectivePoint()
    {
        objectivePoints -= 1;
    }

    private void PlayerDead()
    {
        numPlayersAlive -= 1;
    }

    private void EndGame()
    {
        SceneManager.LoadScene(2);
    }
}
